using KoobooWebMatrixExtension.Properties;
using Microsoft.WebMatrix.Extensibility;
using Microsoft.WebMatrix.Extensibility.Editor;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Windows.Media.Imaging;

namespace KoobooWebMatrixExtension
{
    /// <summary>
    /// A sample WebMatrix extension.
    /// </summary>
    [Export(typeof(Extension))]
    public class KoobooWebMatrixExtension : Extension
    {
        /// <summary>
        /// Stores a reference to the small star image.
        /// </summary>
        private readonly BitmapImage _sourceImageSmall = new BitmapImage(new Uri("pack://application:,,,/KoobooWebMatrixExtension;component/Souce_16x16.png", UriKind.Absolute));

        /// <summary>
        /// Stores a reference to the large star image.
        /// </summary>
        private readonly BitmapImage _sourceImageLarge = new BitmapImage(new Uri("pack://application:,,,/KoobooWebMatrixExtension;component/Souce_32x32.png", UriKind.Absolute));
        private readonly BitmapImage _favIconImageLarge = new BitmapImage(new Uri("pack://application:,,,/KoobooWebMatrixExtension;component/favicon.png", UriKind.Absolute));

        /// <summary>
        /// Stores a reference to the WebMatrix host interface.
        /// </summary>
        private IWebMatrixHost _webMatrixHost;

        /// <summary>
        /// Initializes a new instance of the KoobooWebMatrixExtension class.
        /// </summary>
        public KoobooWebMatrixExtension()
            : base("KoobooWebMatrixExtension")
        {
        }

        /// <summary>
        /// Called to initialize the extension.
        /// </summary>
        /// <param name="host">WebMatrix host interface.</param>
        /// <param name="initData">Extension initialization data.</param>
        protected override void Initialize(IWebMatrixHost host, ExtensionInitData initData)
        {
            _webMatrixHost = host;

            List<RibbonButtonBase> lstItems = new List<RibbonButtonBase>();
            CreateRibbonButton(ref lstItems, "Add new Position", Resources.Position);
            CreateRibbonButton(ref lstItems,"Add new View", Resources.View);

            List<RibbonButtonBase> lstHtmlHelper = new List<RibbonButtonBase>();
            CreateRibbonButton(ref lstHtmlHelper,"Register HtmlMeta", Resources.RegisterMeta);
            CreateRibbonButton(ref lstHtmlHelper,"Register Style", Resources.RegisterStyles);
            CreateRibbonButton(ref lstHtmlHelper,"Register Script", Resources.RegisterScripts);
            CreateRibbonButton(ref lstHtmlHelper,"Register Title", Resources.RegisterTitle);
            CreateRibbonMenu(ref lstItems, "HTML Helper", lstHtmlHelper);

            List<RibbonButtonBase> lstLayouts = new List<RibbonButtonBase>();
            CreateRibbonButton(ref lstLayouts, "Default", Resources.Layout_Default);
            CreateRibbonButton(ref lstLayouts, "One Column", Resources.Layout_OneColumn);
            CreateRibbonButton(ref lstLayouts, "Two Columns", Resources.Layout_TwoColumns);
            CreateRibbonButton(ref lstLayouts, "Three Columns", Resources.Layout_ThreeColumns);
            CreateRibbonMenu(ref lstItems, "Layouts", lstLayouts);

            List<RibbonButtonBase> lstItemsCodeHelper = new List<RibbonButtonBase>();
            CreateRibbonButton(ref lstItemsCodeHelper,"Label", Resources.Label);
            CreateRibbonButton(ref lstItemsCodeHelper,"MultiFilesField", Resources.MultiFilesField);
            CreateRibbonButton(ref lstItemsCodeHelper,"QueryString", Resources.QueryString);
            CreateRibbonButton(ref lstItemsCodeHelper,"RenderHtmlBlock", Resources.RenderHtmlBlock);

            List<RibbonButtonBase> lstContentQuery = new List<RibbonButtonBase>();
            CreateRibbonButton(ref lstContentQuery,"CreateQuery", Resources.ContentQuery_CreateQuery);
            CreateRibbonButton(ref lstContentQuery,"MediaFolder", Resources.ContentQuery_MediaFolder);
            CreateRibbonButton(ref lstContentQuery,"Schema", Resources.ContentQuery_Schema);
            CreateRibbonButton(ref lstContentQuery,"Skip", Resources.ContentQuery_Skip);
            CreateRibbonButton(ref lstContentQuery,"Take", Resources.ContentQuery_Take);
            CreateRibbonButton(ref lstContentQuery,"TextFolder", Resources.ContentQuery_TextFolder);

            List<RibbonButtonBase> lstContentQueryOrder = new List<RibbonButtonBase>();
            CreateRibbonButton(ref lstContentQueryOrder,"OrderBy", Resources.ContentQuery_Order_OrderBy);
            CreateRibbonButton(ref lstContentQueryOrder,"OrderByDescending", Resources.ContentQuery_Order_OrderByDescending);
            CreateRibbonMenu(ref lstContentQuery, "Order", lstContentQueryOrder);

            List<RibbonButtonBase> lstContentQueryResult = new List<RibbonButtonBase>();
            CreateRibbonButton(ref lstContentQueryResult,"Categories", Resources.ContentQuery_Result_Categories);
            CreateRibbonButton(ref lstContentQueryResult,"Children", Resources.ContentQuery_Result_Children);
            CreateRibbonButton(ref lstContentQueryResult,"Count", Resources.ContentQuery_Result_Count);
            CreateRibbonButton(ref lstContentQueryResult,"First", Resources.ContentQuery_Result_First);
            CreateRibbonButton(ref lstContentQueryResult,"FirstOrDefault", Resources.ContentQuery_Result_FirstOrDefault);
            CreateRibbonButton(ref lstContentQueryResult,"Last", Resources.ContentQuery_Result_Last);
            CreateRibbonButton(ref lstContentQueryResult,"LastOrDefault", Resources.ContentQuery_Result_LastOrDefault);
            CreateRibbonButton(ref lstContentQueryResult,"Parent", Resources.ContentQuery_Result_Parent);
            CreateRibbonMenu(ref lstContentQuery, "Result", lstContentQueryResult);

            List<RibbonButtonBase> lstContentQueryWhere = new List<RibbonButtonBase>();
            CreateRibbonButton(ref lstContentQueryWhere,"WhereBetween", Resources.ContentQuery_Where_WhereBetween);
            CreateRibbonButton(ref lstContentQueryWhere,"WhereBetweenOrEqual", Resources.ContentQuery_Where_WhereBetweenOrEqual);
            CreateRibbonButton(ref lstContentQueryWhere,"WhereCategory", Resources.ContentQuery_Where_WhereCategory);
            CreateRibbonButton(ref lstContentQueryWhere,"WhereContains", Resources.ContentQuery_Where_WhereContains);
            CreateRibbonButton(ref lstContentQueryWhere,"WhereEndsWith", Resources.ContentQuery_Where_WhereEndsWith);
            CreateRibbonButton(ref lstContentQueryWhere,"WhereEquals", Resources.ContentQuery_Where_WhereEquals);
            CreateRibbonButton(ref lstContentQueryWhere,"WhereGreaterThan", Resources.ContentQuery_Where_WhereGreaterThan);
            CreateRibbonButton(ref lstContentQueryWhere,"WhereGreaterThanOrEqual", Resources.ContentQuery_Where_WhereGreaterThanOrEqual);
            CreateRibbonButton(ref lstContentQueryWhere,"WhereLessThan", Resources.ContentQuery_Where_WhereLessThan);
            CreateRibbonButton(ref lstContentQueryWhere,"WhereLessThanOrEqual", Resources.ContentQuery_Where_WhereLessThanOrEqual);
            CreateRibbonButton(ref lstContentQueryWhere,"WhereNotEquals", Resources.ContentQuery_Where_WhereNotEquals);
            CreateRibbonButton(ref lstContentQueryWhere,"WhereStartsWith", Resources.ContentQuery_Where_WhereStartsWith);
            CreateRibbonMenu(ref lstContentQuery, "Where", lstContentQueryWhere);
            CreateRibbonMenu(ref lstItemsCodeHelper, "ContentQuery", lstContentQuery);

            List<RibbonButtonBase> lstForms = new List<RibbonButtonBase>();
            CreateRibbonButton(ref lstForms, "Add content", Resources.Form_AddContent);
            CreateRibbonButton(ref lstForms, "Contact us", Resources.Form_ContactUs);
            CreateRibbonButton(ref lstForms, "Delete content", Resources.Form_DeleteContent);
            CreateRibbonButton(ref lstForms, "Search", Resources.Form_Search);
            CreateRibbonButton(ref lstForms, "Update content", Resources.Form_UpdateContent);

            List<RibbonButtonBase> lstAjaxForms = new List<RibbonButtonBase>();
            CreateRibbonButton(ref lstAjaxForms, "Add content", Resources.Form_Ajax_AddContent);
            CreateRibbonButton(ref lstAjaxForms, "Update content", Resources.Form_Ajax_UpdateContent);
            CreateRibbonMenu(ref lstForms, "Ajax", lstAjaxForms);
            CreateRibbonMenu(ref lstItemsCodeHelper, "Forms", lstForms);

            List<RibbonButtonBase> lstInlineEdit = new List<RibbonButtonBase>();
            CreateRibbonButton(ref lstInlineEdit,"Edit field atributes", Resources.InlineEdit_EditFieldAtributes);
            CreateRibbonButton(ref lstInlineEdit,"Edit field", Resources.InlineEdit_EditField);
            CreateRibbonButton(ref lstInlineEdit,"Edit item atributes", Resources.InlineEdit_EditItemAtributes);
            CreateRibbonMenu(ref lstItemsCodeHelper, "Inline Link", lstInlineEdit);

            List<RibbonButtonBase> lstLink = new List<RibbonButtonBase>();
            CreateRibbonButton(ref lstLink,"File url", Resources.Link_FileUrl);
            CreateRibbonButton(ref lstLink,"Media content url", Resources.Link_MediaContentUrl);
            CreateRibbonButton(ref lstLink,"Page link with params", Resources.Link_PageLinkWithParams);
            CreateRibbonButton(ref lstLink,"Page Link", Resources.Link_PageLink);
            CreateRibbonButton(ref lstLink,"Page url", Resources.Link_PageUrl);
            CreateRibbonButton(ref lstLink,"Page url with params", Resources.Link_PageUrlWithParams);
            CreateRibbonButton(ref lstLink,"Resize image url", Resources.Link_ResizeImageUrl);
            CreateRibbonButton(ref lstLink,"Resize image", Resources.Link_ResizeImage);
            CreateRibbonButton(ref lstLink,"Script file url", Resources.Link_ScriptFileUrl);
            CreateRibbonButton(ref lstLink,"SubmissionUrl", Resources.Link_SubmissionUrl);
            CreateRibbonButton(ref lstLink,"Theme file url", Resources.Link_ThemeFileUrl);
            CreateRibbonButton(ref lstLink,"View url with params", Resources.Link_ViewUrlWithParams);
            CreateRibbonMenu(ref lstItemsCodeHelper, "Link", lstLink);

            List<RibbonButtonBase> lstContentMenu = new List<RibbonButtonBase>();
            CreateRibbonButton(ref lstContentMenu, "Breadcrumb", Resources.Menu_Breadcrumb);
            CreateRibbonButton(ref lstContentMenu, "Current page checker", Resources.Menu_CurrentPageChecker);
            CreateRibbonButton(ref lstContentMenu, "Current page", Resources.Menu_CurrentPage);
            CreateRibbonButton(ref lstContentMenu, "Parent page", Resources.Menu_ParentPage);
            CreateRibbonButton(ref lstContentMenu, "Sibling pages", Resources.Menu_SiblingPages);
            CreateRibbonButton(ref lstContentMenu, "Sub pages", Resources.Menu_SubPages);
            CreateRibbonButton(ref lstContentMenu, "Top pages", Resources.Menu_TopPages);
            CreateRibbonMenu(ref lstItemsCodeHelper, "Menu", lstContentMenu);

            List<RibbonItem> lstRibbonButtons = new List<RibbonItem>();
            RibbonMenuButton mnuRibbonItems = new RibbonMenuButton("HTML", lstItems.ToArray(), _sourceImageSmall, _sourceImageLarge);
            RibbonMenuButton mnuRibbonCodeHelper = new RibbonMenuButton("Helpers", lstItemsCodeHelper.ToArray(), _sourceImageSmall, _sourceImageLarge);
            lstRibbonButtons.Add(mnuRibbonItems);
            lstRibbonButtons.Add(mnuRibbonCodeHelper);

            RibbonGroup ribbonGroup = new RibbonGroup("Kooboo", lstRibbonButtons.ToArray(), _favIconImageLarge);

            // Add a simple button to the Ribbon
            initData.RibbonItems.Add(ribbonGroup);
        }

        /// <summary>
        /// Creates the ribbon menu.
        /// </summary>
        /// <param name="lst">The LST.</param>
        /// <param name="title">The title.</param>
        /// <param name="items">The items.</param>
        private void CreateRibbonMenu(ref List<RibbonButtonBase> lst, string title, List<RibbonButtonBase> items)
        {
            lst.Add(new RibbonMenuButton(title, items.ToArray(), _sourceImageSmall, _sourceImageLarge));
        }

        /// <summary>
        /// Creates the ribbon button.
        /// </summary>
        /// <param name="lst">The LST.</param>
        /// <param name="title">The title.</param>
        /// <param name="parameter">The parameter.</param>
        private void CreateRibbonButton(ref List<RibbonButtonBase> lst, string title, string parameter)
        {
            lst.Add(new RibbonButton(title, new DelegateCommand(HandleRibbonButtonInvoke), parameter, _sourceImageSmall, _sourceImageLarge));
        }

        /// <summary>
        /// Called when the Ribbon button is invoked.
        /// </summary>
        /// <param name="parameter">Unused.</param>
        private void HandleRibbonButtonInvoke(object parameter)
        {
            try
            {
                SetText(parameter.ToString());
            }
            catch (Exception ex)
            {
                _webMatrixHost.ShowErrorNotification(ex.Message);
            }
        }

        /// <summary>
        /// Gets the editor.
        /// </summary>
        /// <returns></returns>
        private IEditor GetEditor()
        {
            var workspace = _webMatrixHost.Workspace as IEditorWorkspace;

            if (workspace != null)
            {
                return workspace.CurrentEditor;
            }
            else
            {
                return null;
            }            
        }

        /// <summary>
        /// Sets the text.
        /// </summary>
        /// <param name="insertText">The insert text.</param>
        private void SetText(string insertText)
        {
            var editor = GetEditor();

            if (editor != null)
            {
                var selection = editor.ServiceProvider.GetService(typeof(IEditorSelection)) as IEditorSelection;

                if (selection != null && !selection.IsBlockSelection)
                {
                    selection.InsertText(insertText);
                    editor.Focus();
                }
            }
        }

    }
}
