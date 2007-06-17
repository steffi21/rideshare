<%@ Page Language="C#" MasterPageFile="~/rideShare.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" %>
<%@ Register TagPrefix="rideshare" TagName="ui" Src="~/controls/userInterface.ascx" %>
<%@ Register TagPrefix="rideshare" TagName="map" Src="~/controls/map.ascx" %>

<asp:Content ID="defaultContent" ContentPlaceHolderID="mainContent" runat="server">
    <div id="tabContainer">
        <div class="yui-g">
            <div class="yui-u first tab1"> 
                <rideshare:ui id="uiControl" runat="server" uiStep="1"></rideshare:ui>
            </div>
            <div class="yui-u">
                <rideshare:map id="map" runat="server" />
            </div>
        </div>
        <div class="yui-g tab2">
            <rideshare:ui id="uiControlStep2" runat="server" uiStep="2" Visible="true"></rideshare:ui>
        </div>
    </div>
    
</asp:Content>
