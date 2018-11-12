using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.UI.WebControls;
using DevExpress.Web;
using DevExpress.Web.Mvc;

namespace SmartQA1._1._2.Views.CommonSettings
{
    public static class MainGridView
    {
        /// <summary>
        /// Applies all necessary alterations for GridView context menu
        /// </summary>
        public static GridViewSettings ApplyContextMenuSettings(this GridViewSettings settings)
        {
            string OnContextMenu = 
            @"function (s, e)
            {
                s.SetFocusedRowIndex(e.index);
                e.showBrowserMenu = false;
            }";
            settings.CommandColumn.Visible = false;
            settings.SettingsBehavior.EnableRowHotTrack = true;
            settings.ClientSideEvents.ContextMenu = OnContextMenu;
            settings.SettingsBehavior.AllowFocusedRow = true;
            settings.SettingsContextMenu.Enabled = true;
            settings.SettingsText.GroupPanel = "Перетащите сюда название колонки, чтобы сгруппировать";

            settings.FillContextMenuItems = (s, e) =>
            {
                if (e.MenuType == GridViewContextMenuType.Rows)
                {
                    //remove "Refresh" button:
                    var refreshButton = e.Items[e.Items.IndexOfCommand(GridViewContextMenuCommand.Refresh)];
                    e.Items.Remove(refreshButton);

                    //remove add "Create new" button
                    var createNewButton = e.Items[e.Items.IndexOfCommand(GridViewContextMenuCommand.NewRow)];
                    e.Items.Remove(createNewButton);
                }
            };
            return settings;
        }
        /// <summary>
        /// Adds "Copy" button to the existing context menu
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static GridViewSettings AddCopyButton(this GridViewSettings settings)
        {
            var contextMenuHandler = settings.FillContextMenuItems;
            if (contextMenuHandler == null)
                throw new NullReferenceException(
                    "Method 'ApplyContextMenuSettings(GridViewSettings)' " +
                    "has to be applied right before method 'AddCopyButton(GridViewSettings)'");
            contextMenuHandler += (s, e) =>
            {
                if (e.MenuType == GridViewContextMenuType.Rows)
                {
                    //add "Copy" button:
                    var item = e.CreateItem("Copy", "Copy");
                    item.Image.IconID = DevExpress.Web.ASPxThemes.IconID.EditCopy16x16office2013;
                    e.Items.Insert(e.Items.IndexOfCommand(GridViewContextMenuCommand.DeleteRow), item);
                }
            };
            settings.FillContextMenuItems = contextMenuHandler;
            return settings;
        }
        /// <summary>
        /// Applies all necessary alterations for GridView edit mode
        /// </summary>
        /// <param name="contentAction">Content Action to be called to render popup stuffings</param>
        public static GridViewSettings ApplyEditPopupSettings(this GridViewSettings settings, Action<GridViewEditFormTemplateContainer> contentAction)
        {
            settings.SettingsEditing.Mode = GridViewEditingMode.PopupEditForm;
            settings.SettingsPopup.EditForm.HorizontalAlign = PopupHorizontalAlign.WindowCenter;
            settings.SettingsPopup.EditForm.VerticalAlign = PopupVerticalAlign.WindowCenter;
            settings.SettingsPopup.EditForm.Modal = true;
            settings.SettingsPopup.EditForm.ShowCloseButton = false;
            settings.SetEditFormTemplateContent(contentAction);
            return settings;
        }

        public static GridViewSettings ApplyCommonGridViewSettings(this GridViewSettings settings)
        {
            //BORDER COLOR:
            var borderColor = System.Drawing.Color.FromArgb(230, 230, 230);
            settings.ControlStyle.Border.BorderColor = borderColor;
            settings.Styles.Cell.Border.BorderColor = borderColor;
            settings.Styles.Header.Border.BorderColor = borderColor;
            settings.Styles.GroupPanel.Border.BorderColor = borderColor;
            settings.Styles.FocusedRow.BackColor = System.Drawing.Color.FromArgb(150, 150, 150);

            settings.Width = Unit.Percentage(100);
            return settings;
        }
    }
}