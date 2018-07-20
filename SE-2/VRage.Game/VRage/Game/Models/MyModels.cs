namespace VRage.Game.Models
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Threading;
    using VRage.Collections;
    using VRage.Utils;

    public static class MyModels
    {
        private static readonly AutoResetEvent m_loadModelEvent = new AutoResetEvent(false);
        private static MyConcurrentDictionary<string, MyModel> m_models = new MyConcurrentDictionary<string, MyModel>(0, null);

        public static List<MyModel> GetLoadedModels()
        {
            List<MyModel> result = new List<MyModel>();
            m_models.GetValues(result);
            return result;
        }

        public static MyModel GetModel(string modelAsset)
        {
            MyModel model;
            if ((modelAsset != null) && m_models.TryGetValue(modelAsset, out model))
            {
                return model;
            }
            return null;
        }

        public static MyModel GetModelOnlyAnimationData(string modelAsset, bool forceReloadMwm = false)
        {
            MyModel model;
            if (forceReloadMwm || !m_models.TryGetValue(modelAsset, out model))
            {
                model = new MyModel(modelAsset);
                m_models[modelAsset] = model;
            }
            try
            {
                model.LoadAnimationData();
                return model;
            }
            catch (Exception exception)
            {
                MyLog.Default.WriteLine(exception);
                return null;
            }
        }

        public static MyModel GetModelOnlyData(string modelAsset)
        {
            MyModel model;
            if (string.IsNullOrEmpty(modelAsset))
            {
                return null;
            }
            if (!m_models.TryGetValue(modelAsset, out model))
            {
                model = new MyModel(modelAsset);
                m_models[modelAsset] = model;
            }
            model.LoadData();
            return model;
        }

        public static MyModel GetModelOnlyDummies(string modelAsset)
        {
            MyModel model;
            if (!m_models.TryGetValue(modelAsset, out model))
            {
                model = new MyModel(modelAsset);
                m_models[modelAsset] = model;
            }
            model.LoadOnlyDummies();
            return model;
        }

        public static MyModel GetModelOnlyModelInfo(string modelAsset)
        {
            MyModel model;
            if (!m_models.TryGetValue(modelAsset, out model))
            {
                model = new MyModel(modelAsset);
                m_models[modelAsset] = model;
            }
            model.LoadOnlyModelInfo();
            return model;
        }

        public static void UnloadData()
        {
            foreach (MyModel model in GetLoadedModels())
            {
                model.UnloadData();
            }
            m_models.Clear();
        }
    }
}

