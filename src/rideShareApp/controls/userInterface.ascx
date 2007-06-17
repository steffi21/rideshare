<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="userInterface.ascx.cs" Inherits="rideShareApp.userInterface" %>

<asp:placeholder ID="placeholderStep1" runat="server" Visible="false">
        <div id="step1">
            <div class="hd">
                <h1>Step 1</h1>
            </div>
            <div class="bd">
                <div id="selectEventContainer">
                <asp:DropDownList id="selectEvent" runat="server" OnTextChanged="loadEvent">
                    <asp:ListItem>  -- Choose An Event --  </asp:ListItem>
                    <asp:ListItem> -- Test -- </asp:ListItem>
                </asp:DropDownList>
                                            <!--<asp:Repeater ID="literalSelectEventOptions" runat="server" >
                            <HeaderTemplate>
                                <label for="selectEvent" >Select an event,</label>
                                <select id="selectEvent" onchange="loadEvent">
                            </HeaderTemplate>
                            <ItemTemplate>
                                <option> -- Choose An Event -- </option>
                            </ItemTemplate>
                            <FooterTemplate>
                                </select>
                            </FooterTemplate>
                        </asp:Repeater> -->
                </div>
            </div>
            <div class="ft">
            
            </div>
        </div>

        <div id="step1Details">
            <div class="hd">
                <h2>EVENT NAME</h2>
            </div>
            <div class="bd">
                <asp:Literal ID="eventDetails" runat="server"></asp:Literal>
            </div>
            <div class="ft">
            
            </div>
        </div>
</asp:placeholder>
<asp:placeholder ID="placeholderStep2" runat="server" Visible="false">
        <div id="step2">
            <div class="hd">
                <h1>Step 2</h1>
            </div>
            <div class="bd">
                   <h3>Where are you coming from</h3>
                   <div class="row">
                        <label for="txtPostCode">Post Code:</label>
                        <input id="txtPostCode" type="text"/>
                   </div>
                   <div class="row">
                        <label for="hiddenCoOrdinates">or Plot your location on the map</label>
                        <input id="hiddenCoOrdinates" type="hidden"/>
                   </div>
                   
                   <h3>Find rideShares who are:</h3>
                   
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                        <asp:ListItem Value="going">Going to Event</asp:ListItem>
                        <asp:ListItem Selected="True" Value="return">Returning from Event</asp:ListItem> 
                    </asp:RadioButtonList>
                    
                   </div>
            </div>
            <div class="ft">
            </div>
        </div>
</asp:placeholder>

