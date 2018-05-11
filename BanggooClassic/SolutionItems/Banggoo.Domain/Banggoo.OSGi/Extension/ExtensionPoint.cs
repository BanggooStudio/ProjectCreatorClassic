using Banggoo.OSGi.Core;

namespace Banggoo.OSGi.Extension
{
    /// <summary>
    /// 扩展点实体
    /// </summary>
    public class ExtensionPoint
    {
        /// <summary>
        /// 扩展点名称
        /// </summary>
        public string Name { set; get; }


        /// <summary>
        /// 拥有Bundle
        /// </summary>
        public IBundle Owner { set; get; }
    }
}