﻿using Metro.DynamicModeules.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace Metro.DynamicModeules.Core
{
    /// <summary>
    /// 加载模块管理类(Load Module Manager)
    /// </summary>
    public class ModuleLoaderBase
    {
        private ModuleLoaderBase()
        {
            Compile();
        }
        static object _instanceLock = new object();
        ModuleLoaderBase _instance;
        public ModuleLoaderBase Instance
        {
            get
            {
                if(null== _instance)
                {
                    lock (_instanceLock)
                    {
                        if (null == _instance)
                        {
                            _instance = new ModuleLoaderBase();
                        }
                    }
                }
                return _instance;
            }
        }
        /// <summary>
        /// 模块文件名(DLL文件外)
        /// </summary>
        // protected string _ModuleFileName;

        /// <summary>
        /// 如果加载了模块. 返回该模块的主窗体对象.
        /// </summary>
        // protected IModuleBase _ModuleMainForm;

        /// <summary>
        /// 存储所有插件
        /// </summary>
        [ImportMany(typeof(IModuleBase), AllowRecomposition = true)]
        public List<Lazy<IModuleBase>> PluginList { get; set; }


        /// <summary>  
        /// 通过容器对象将宿主和部件组装到一起。  
        /// </summary>  
        public void Compile()
        {
            PluginList = new List<Lazy<IModuleBase>>();
            AggregateCatalog aggregateCatalog = new AggregateCatalog();
            AssemblyCatalog assemblyCatalog = new AssemblyCatalog(typeof(IModuleBase).Assembly);
            DirectoryCatalog directoryCatalog = new DirectoryCatalog("modules");
            aggregateCatalog.Catalogs.Add(assemblyCatalog);
            aggregateCatalog.Catalogs.Add(directoryCatalog);
            var container = new CompositionContainer(aggregateCatalog);
            container.ComposeParts(this);
        }
        /// <summary>
        /// 模块所在的程序集
        /// </summary>
        //protected Assembly _ModuleAssembly;

        ///// <summary>
        ///// 模块文件所在路径
        ///// </summary>
        //public static readonly string MODULE_PATH = Application.StartupPath;

        ///// <summary>
        ///// 模块所在的程序集
        ///// </summary>
        //public Assembly ModuleAssembly
        //{
        //    get { return _ModuleAssembly; }
        //}

        /// <summary>
        /// 返回AssemblyModuleEntry，自定义模块特性
        /// </summary>
        //public string GetCurrentModuleName()
        //{
        //    return ModuleLoaderBase.GetModuleEntry(_ModuleAssembly).ModuleName;
        //}

        /// <summary>
        /// 模块主窗体
        /// </summary>
        //public IModuleBase ModuleMainForm
        //{
        //    get { return _ModuleMainForm; }
        //}

        ///// <summary>
        ///// 加载模块的菜单
        ///// </summary>
        ///// <param name="menuStrip">程序主窗体的菜单</param>
        //public virtual void LoadMenu(MenuStrip moduleMenus)
        //{
        //    MenuStrip currentMenu = _ModuleMainForm.GetModuleMenu();
        //    if ((currentMenu == null) || (currentMenu.Items.Count == 0)) return;

        //    if (_ModuleMainForm != null)
        //    {
        //        int startIndex = moduleMenus.Items.Count == 0 ? 0 : moduleMenus.Items.Count;
        //        moduleMenus.Items.Insert(startIndex, _ModuleMainForm.GetModuleMenu().Items[0]);
        //    }
        //}

        /// <summary>
        /// 加载模块的菜单(支持一个模块内有多个顶级菜单)
        /// </summary>
        /// <param name="menuStrip">程序主窗体的菜单</param>
        public virtual void LoadMenu(Menu moduleMenus)
        {
            //Menu moduleMenu = _ModuleMainForm.GetModuleMenu();//当前模块的菜单
            //if ((moduleMenu == null) || (moduleMenu.Items.Count == 0)) return;

            //if (_ModuleMainForm != null)
            //{
            //    while (moduleMenu.Items.Count > 0)//加载所有顶级菜单
            //    {
            //        int startIndex = moduleMenus.Items.Count == 0 ? 0 : moduleMenus.Items.Count;
            //        moduleMenus.Items.Insert(startIndex, moduleMenu.Items[0]);
            //    }
            //}
        }

        /// <summary>
        /// 加载模块主方法
        /// </summary>
        /// <param name="moduleinfo">模块信息</param>
        /// <returns></returns>
        public virtual bool LoadModule(IModuleBase moduleinfo)
        {
            //_ModuleFileName = moduleinfo.ModuleFile;
            //_ModuleAssembly = moduleinfo.ModuleAssembly;
            //string entry = GetModuleEntryNameSpace(_ModuleAssembly);
            //if (string.Empty == entry) return false;

            //Form form = (Form)_ModuleAssembly.CreateInstance(entry);
            //_ModuleMainForm = null;

            //if (form is IModuleBase) _ModuleMainForm = (IModuleBase)form;

            //return _ModuleMainForm != null;
            return false;
        }

        /// <summary>        
        /// 获取模块列表，转换为ModuleInfo集合.
        /// </summary>        
        //public virtual IList<ModuleInfo> GetModuleList()
        //{
        //    try
        //    {
        //        string[] files = null; //模块文件(*.dll)
        //        IList<ModuleInfo> list = new List<ModuleInfo>();

        //        if (Directory.Exists(MODULE_PATH))
        //            files = Directory.GetFiles(MODULE_PATH, "*Module.dll");

        //        foreach (string mod in files)
        //        {
        //            Assembly asm = null;
        //            try
        //            {
        //                //.net framework dll
        //                asm = Assembly.LoadFile(mod);
        //            }
        //            catch { continue; }

        //            ModuleID id = GetModuleID(asm);
        //            string name = GetCurrentModuleName();
        //            if (id != ModuleID.None)
        //            {
        //                ModuleInfo m = new ModuleInfo(asm, id, name, mod);
        //                list.Add(m);
        //            }
        //        }
        //        var vlst = (from i in list orderby i.ModuleID ascending select i).ToList();
        //        //SortModule(list); //模块排序.
        //        return vlst;
        //    }
        //    catch (Exception ex)
        //    {
        //        Msg.ShowException(ex);
        //        return null;
        //    }
        //}

        /// <summary>
        /// 获取程序集自定义特性。
        /// </summary>
        /// <returns></returns>
        //public AssemblyModuleEntry GetModuleEntry()
        //{
        //    return ModuleLoaderBase.GetModuleEntry(_ModuleAssembly);
        //}

        /// <summary>
        /// 判断加载的文件是否模块文件，因目录下可能有不同类别的DLL文件。
        /// 判断DLL文件是否框架模块通过检查Assembly特性。
        /// </summary>
        //public bool IsModuleFile(string moduleFile)
        //{
        //    try
        //    {
        //        Assembly asm = Assembly.LoadFile(moduleFile);
        //        return (ModuleLoaderBase.GetModuleID(asm) != ModuleID.None);
        //    }
        //    catch { return false; }
        //}

        /// <summary>
        /// 每一个模块对应一个TabPage, 将模块主窗体的Panel容器放置在TabPage内。
        /// 因此，所有加载的模块主窗体的Panel容器都嵌套在主窗体的TabControl内。
        /// </summary>
        public virtual void LoadGUI(object mainTabControl) { }

        /// <summary>
        /// 模块排序
        /// </summary>
        /// <param name="list"></param>
        //public virtual void SortModule(IList<ModuleInfo> list)
        //{
        //    int i, j;
        //    ModuleInfo temp;
        //    bool done = false;
        //    j = 1;
        //    while ((j < list.Count) && (!done))
        //    {
        //        done = true;
        //        for (i = 0; i < list.Count - j; i++)
        //        {
        //            if ((list[i] as ModuleInfo).ModuleID > (list[i + 1] as ModuleInfo).ModuleID)
        //            {
        //                done = false;
        //                temp = list[i];
        //                list[i] = list[i + 1];
        //                list[i + 1] = temp;
        //            }
        //        }
        //    }
        //}

        #region 类公共静态方法

        /// <summary>
        /// 查找子菜单，深度搜索
        /// </summary>
        //public static MenuItem GetMenuItem(ToolStrip mainMenu, string menuName)
        //{
        //    ToolStripItem[] items = mainMenu.Items.Find(menuName, true);
        //    if (items.Length > 0 && items[0] is ToolStripMenuItem)
        //        return (ToolStripMenuItem)items[0];
        //    else
        //        return null;
        //}

        /// <summary>
        /// 获取程序集自定义特性。是否用户自定义模块由AssemblyModuleEntry特性确定。
        /// </summary>
        //public static AssemblyModuleEntry GetModuleEntry(Assembly asm)
        //{
        //    AssemblyModuleEntry temp = new AssemblyModuleEntry(ModuleID.None, "", "");
        //    if (asm == null) return temp;

        //    object[] list = asm.GetCustomAttributes(typeof(AssemblyModuleEntry), false);
        //    if (list.Length > 0)
        //        return (AssemblyModuleEntry)list[0];
        //    else
        //        return temp;
        //}

        /// <summary>
        /// 获取模块主窗体名字空间
        /// </summary>
        //public static string GetModuleEntryNameSpace(Assembly asm)
        //{
        //    return GetModuleEntry(asm).ModuleEntryNameSpace;
        //}

        /// <summary>
        /// 获取模块编号
        /// </summary>
        //public static ModuleID GetModuleID(Assembly asm)
        //{
        //    return ModuleLoaderBase.GetModuleEntry(asm).ModuleID;
        //}

        #endregion

        /// <summary>
        /// 判断当前用户是否有该模块的权限
        /// </summary>
        /// <param name="userPermissions">用户权限</param>
        /// <returns></returns>
        //public bool CanAccessModule(DataTable userRights)
        //{
        //    if (Loginer.CurrentUser.IsAdmin()) return true;
        //    MenuStrip mainMenu = _ModuleMainForm.GetModuleMenu();
        //    DataRow[] rows = userRights.Select(string.Format("AuthorityID='{0}'", mainMenu.Items[0].Name));
        //    return rows != null && rows.Length > 0;
        //}

        /// <summary>
        /// 程序集对象引用置空，优化GC回收内存
        /// </summary>
        //public void ClearAssemble()
        //{
        //    _ModuleAssembly = null;
        //    _ModuleMainForm = null;
        //}
    }
}
