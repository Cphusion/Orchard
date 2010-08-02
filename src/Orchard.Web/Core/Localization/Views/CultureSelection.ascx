﻿<%@ Control Language="C#" Inherits="Orchard.Mvc.ViewUserControl<Orchard.Core.Localization.ViewModels.AddLocalizationViewModel>" %>
<fieldset class="localization culture-selection">
    <label for="SelectedCulture"><%:T("Content Localization") %></label><%
    var siteCultures = Model.SiteCultures.ToList();
    siteCultures.Insert(0, ""); %>
    <div><%=T("This is the <em>{0}</em> variation of {1}.",
        Html.DropDownList("SelectedCulture", new SelectList(siteCultures, Model.SelectedCulture)),
        Html.ItemEditLink(Model.Content.Item)) %></div>
</fieldset>