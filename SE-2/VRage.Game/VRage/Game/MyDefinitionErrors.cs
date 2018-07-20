namespace VRage.Game
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using VRage.Collections;
    using VRage.Utils;
    using VRageMath;

    public static class MyDefinitionErrors
    {
        private static readonly ErrorComparer m_comparer = new ErrorComparer();
        private static readonly List<Error> m_errors = new List<Error>();
        private static readonly object m_lockObject = new object();

        public static void Add(MyModContext context, string message, TErrorSeverity severity, bool writeToLog = true)
        {
            Error item = new Error {
                ModName = context.ModName,
                ErrorFile = context.CurrentFile,
                Message = message,
                Severity = severity
            };
            lock (m_lockObject)
            {
                m_errors.Add(item);
            }
            string modName = context.ModName;
            if (writeToLog)
            {
                WriteError(item);
            }
            if (severity == TErrorSeverity.Critical)
            {
                ShouldShowModErrors = true;
            }
        }

        public static void Clear()
        {
            lock (m_lockObject)
            {
                m_errors.Clear();
            }
        }

        public static ListReader<Error> GetErrors()
        {
            lock (m_lockObject)
            {
                m_errors.Sort(m_comparer);
                return new ListReader<Error>(m_errors);
            }
        }

        public static void WriteError(Error e)
        {
            MyLog.Default.WriteLine($"{e.ErrorSeverity}: {e.ModName ?? string.Empty}");
            MyLog.Default.WriteLine(("  in file: " + e.ErrorFile) ?? string.Empty);
            MyLog.Default.WriteLine("  " + e.Message);
        }

        public static bool ShouldShowModErrors
        {
            [CompilerGenerated]
            get => 
                <ShouldShowModErrors>k__BackingField;
            [CompilerGenerated]
            set
            {
                <ShouldShowModErrors>k__BackingField = value;
            }
        }

        public class Error
        {
            public string ErrorFile;
            public string Message;
            public string ModName;
            public TErrorSeverity Severity;
            private static Color[] severityColors = new Color[] { Color.Gray, Color.Gray, Color.White, new Color(1f, 0.25f, 0.1f) };
            private static string[] severityName = new string[] { "notice", "warning", "error", "critical error" };
            private static string[] severityNamePlural = new string[] { "notices", "warnings", "errors", "critical errors" };

            public Color GetSeverityColor() => 
                GetSeverityColor(this.Severity);

            public static Color GetSeverityColor(TErrorSeverity severity)
            {
                try
                {
                    return severityColors[(int) severity];
                }
                catch (Exception exception)
                {
                    MyLog.Default.WriteLine($"Error type does not have color assigned: message: {exception.Message}, stack:{exception.StackTrace}");
                    return Color.White;
                }
            }

            public static string GetSeverityName(TErrorSeverity severity, bool plural)
            {
                try
                {
                    if (plural)
                    {
                        return severityNamePlural[(int) severity];
                    }
                    return severityName[(int) severity];
                }
                catch (Exception exception)
                {
                    MyLog.Default.WriteLine($"Error type does not have name assigned: message: {exception.Message}, stack:{exception.StackTrace}");
                    return (plural ? "Errors" : "Error");
                }
            }

            public override string ToString() => 
                $"{this.ErrorSeverity}: {(this.ModName ?? string.Empty)}, in file: {this.ErrorFile}
{this.Message}";

            public string ErrorId
            {
                get
                {
                    if (this.ModName != null)
                    {
                        return "mod_";
                    }
                    return "definition_";
                }
            }

            public string ErrorSeverity
            {
                get
                {
                    string errorId = this.ErrorId;
                    switch (this.Severity)
                    {
                        case TErrorSeverity.Notice:
                            return (errorId + "notice");

                        case TErrorSeverity.Warning:
                            return (errorId + "warning");

                        case TErrorSeverity.Error:
                            return (errorId + "error").ToUpperInvariant();

                        case TErrorSeverity.Critical:
                            return (errorId + "critical_error").ToUpperInvariant();
                    }
                    return errorId;
                }
            }
        }

        public class ErrorComparer : IComparer<MyDefinitionErrors.Error>
        {
            public int Compare(MyDefinitionErrors.Error x, MyDefinitionErrors.Error y) => 
                ((int) (y.Severity - x.Severity));
        }
    }
}

