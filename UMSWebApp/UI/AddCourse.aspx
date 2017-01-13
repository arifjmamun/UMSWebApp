<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Main.Master" AutoEventWireup="true" CodeBehind="AddCourse.aspx.cs" Inherits="UMSWebApp.UI.AddCourse" %>

<asp:Content ID="head" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="body" ContentPlaceHolderID="bodyContent" runat="server">
    <div class="row">
        <div class="col-md-offset-1 col-md-10">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">Add Course 
                        <asp:Label runat="server" ID="msgLabel" CssClass="pull-right msg"></asp:Label>
                    </h3>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-offset-3 col-md-6">
                            <div class="form-horizontal">
                                <%--Course Code TextBox--%>
                                <div class="form-group">
                                    <label for="courseCodeTextBox" class="control-label col-sm-4">Course Code</label>
                                    <div class="col-sm-8">
                                        <asp:TextBox ID="courseCodeTextBox" runat="server" ClientIDMode="Static" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <%--Course Tile TextBox--%>
                                <div class="form-group">
                                    <label for="courseTtileTextBox" class="control-label col-sm-4">Course Title</label>
                                    <div class="col-sm-8">
                                        <asp:TextBox ID="courseTtileTextBox" runat="server" ClientIDMode="Static" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <%--Course Credit TextBox--%>
                                <div class="form-group">
                                    <label for="courseCreditTextBox" class="control-label col-sm-4">Course Credit</label>
                                    <div class="col-sm-8">
                                        <asp:TextBox ID="courseCreditTextBox" runat="server" ClientIDMode="Static" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <%--Buttons--%>
                                <div class="form-group">
                                    <div class="col-sm-12">
                                        <asp:Button CssClass="btn btn-default pull-right" runat="server" ID="showButton" Text="Show" OnClick="showButton_Click" />
                                        <asp:Button CssClass="btn btn-success pull-right btn-space" runat="server" ID="addButton" Text="Add" OnClick="addButton_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="table-responsive">
                            <asp:GridView ID="courseGridView" runat="server" ClientIDMode="Static" CssClass="table table-striped" GridLines="None" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True">
                                <Columns>
                                    <asp:TemplateField HeaderText="SL#">
                                        <ItemTemplate><%#Eval("Id") %></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Course Title">
                                        <ItemTemplate><%#Eval("Title") %></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Course Code">
                                        <ItemTemplate><%#Eval("Code") %></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Course Credit">
                                        <ItemTemplate><%#Eval("Credit") %></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:HyperLink runat="server" NavigateUrl='<%#String.Format("AddCourse.aspx?Id={0}",Eval("Id")) %>'><span class="label label-info"> Edit</span></asp:HyperLink>
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
    </div>
</asp:Content>
<asp:Content ID="script" ContentPlaceHolderID="scriptContent" runat="server">
</asp:Content>
