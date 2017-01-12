<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Main.Master" AutoEventWireup="true" CodeBehind="StudentEntry.aspx.cs" Inherits="UMSWebApp.UI.StudentEntry" %>

<asp:Content ID="head" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>

<asp:Content ID="body" ContentPlaceHolderID="bodyContent" runat="server">
    <div class="row">
        <div class="col-md-offset-1 col-md-10">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">Student Entry</h3>
                </div>
                <div class="panel-body">
                    <div class="col-md-offset-3 col-md-6">
                        <div class="form-horizontal">
                            <%--Department Dropdown--%>
                            <div class="form-group">
                                <label for="departmentDropDownList" class="control-label col-sm-4">Department</label>
                                <div class="col-sm-8">
                                    <asp:DropDownList ID="departmentDropDownList" runat="server" CssClass="form-control" ClientIDMode="Static">
                                        <asp:ListItem Value="" Text="Select One"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <%--Name TextBox--%>
                            <div class="form-group">
                                <label for="nameTextBox" class="control-label col-sm-4">Name</label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="nameTextBox" runat="server" ClientIDMode="Static" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <%--Registration Number TextBox--%>
                            <div class="form-group">
                                <label for="regNoTextBox" class="control-label col-sm-4">Registration No.</label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="regNoTextBox" runat="server" ClientIDMode="Static" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <%--Phone Number TextBox--%>
                            <div class="form-group">
                                <label for="phoneNoTextBox" class="control-label col-sm-4">Phone No.</label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="phoneNoTextBox" runat="server" ClientIDMode="Static" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <%--Address TextBox--%>
                            <div class="form-group">
                                <label for="addressTextBox" class="control-label col-sm-4">Address</label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="addressTextBox" TextMode="MultiLine" runat="server" ClientIDMode="Static" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                             <%--Buttons--%>
                            <div class="form-group">
                                <div class="col-sm-12">
                                    <asp:Button CssClass="btn btn-default pull-right" runat="server" ID="showButton" Text="Show"/>&nbsp;&nbsp;&nbsp; 
                                    <asp:Button CssClass="btn btn-default pull-right btn-space" runat="server" ID="saveButton" Text="Save"/>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="table-responsive">
                        <asp:GridView ID="GridView1" runat="server" ClientIDMode="Static" CssClass="table table-striped" GridLines="None" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True">
                            <Columns>
                                <asp:TemplateField HeaderText="SL#">
                                    <ItemTemplate><%#Eval("Serial") %></ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Name">
                                    <ItemTemplate><%#Eval("Name") %></ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Reg. No.">
                                    <ItemTemplate><%#Eval("RegNo") %></ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Phone No.">
                                    <ItemTemplate><%#Eval("PhoneNo")%></ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Address">
                                    <ItemTemplate><%#Eval("Address")%></ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Department">
                                    <ItemTemplate><%#Eval("Department")%></ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <asp:HyperLink runat="server" NavigateUrl='<%#String.Format("StudentEntry.aspx?regNo={0}",Eval("RegNo")) %>'>Edit</asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>No records available.</EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>

<asp:Content runat="server" ID="script" ContentPlaceHolderID="scriptContent">
</asp:Content>
