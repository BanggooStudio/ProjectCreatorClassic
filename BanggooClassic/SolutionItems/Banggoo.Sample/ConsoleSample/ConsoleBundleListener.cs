﻿using System;
using System.Reflection;
using Banggoo.OSGi.Event;
using Banggoo.OSGi.Listener;

namespace ConsoleSample
{
    class ConsoleBundleListener : IBundleListener
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void BundleChanged(BundleEventArgs e)
        {
            Type bundleEventType = typeof(BundleEventArgs);
            String stateString = e.GetState().ToString();
            foreach (FieldInfo fi in bundleEventType.GetFields())
            {
                if (!fi.IsPublic || !fi.IsStatic || !fi.IsLiteral || !fi.FieldType.Equals(typeof(Int32))) continue;
                Int32 fieldValue = (Int32)fi.GetValue(null);
                if (e.GetState() == fieldValue)
                {
                    stateString = fi.Name;
                    break;
                }
            }
            log.Debug(String.Format("{0}状态已改变为[{1}]", e.GetBundle().ToString(), stateString));
        }
    }
}
