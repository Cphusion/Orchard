﻿<%@ Control Language="C#" Inherits="Orchard.Mvc.ViewUserControl<Orchard.Core.Common.ViewModels.CommonMetadataViewModel>" %>
    <ul class="pageStatus">
        <li><%
        if (Model.ModifiedUtc.HasValue) { %>
            <%:T("Last modified: {0}", Html.DateTimeRelative(Model.ModifiedUtc.Value, T)) %><%
        } %>&nbsp;&#124;&nbsp;
        </li>
        <li><%:T("By {0}", Model.Creator.UserName) %></li>
    </ul>