<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <asp:Button Text="+" ID="btnVolumeUp" runat="server" OnClick="btnVolumeUp_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button Text="-" ID="btnVolumeDown" runat="server" OnClick="btnVolumeDown_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
       <asp:Button Text="Mute" ID="btnMute" runat="server" OnClick="btnMute_Click" />


    </div>

    <div class="row">
        <div class="col-md-4">
        </div>
        <div class="col-md-4">
        </div>
        <div class="col-md-4">
        </div>
    </div>
</asp:Content>
