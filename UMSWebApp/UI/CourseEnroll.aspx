<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Main.Master" AutoEventWireup="true" CodeBehind="CourseEnroll.aspx.cs" Inherits="UMSWebApp.UI.CourseEnroll" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">
    <div class="row">
        <div class="col-md-offset-1 col-md-10">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">Course Enrollment 
                        <asp:Label runat="server" ID="msgLabel" CssClass="pull-right msg"></asp:Label>
                    </h3>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-offset-3 col-md-6">
                            <div class="form-horizontal">
                                <%--Student Registration No Dropdown--%>
                                <div class="form-group">
                                    <label for="studentRegNoDropDownList" class="control-label col-sm-4">Student Reg. No.</label>
                                    <div class="col-sm-8">
                                        <asp:DropDownList ID="studentRegNoDropDownList" runat="server" CssClass="form-control" ClientIDMode="Static">
                                            <asp:ListItem Value="" Text="Select One"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <%--Course Title Dropdown--%>
                                <div class="form-group">
                                    <label for="coursesDropDownList" class="control-label col-sm-4">Course Title</label>
                                    <div class="col-sm-8">
                                        <asp:DropDownList ID="coursesDropDownList" runat="server" CssClass="form-control" ClientIDMode="Static">
                                            <asp:ListItem Value="" Text="Select One"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <%--Enroll Date TextBox--%>
                                <div class="form-group">
                                    <label for="enrollDateTextBox" class="control-label col-sm-4">Enroll Date</label>
                                    <div class="col-sm-8">
                                        <asp:TextBox ID="enrollDateTextBox" runat="server" ClientIDMode="Static" CssClass="form-control calender-date"></asp:TextBox>
                                    </div>
                                </div>
                                <%--Buttons--%>
                                <div class="form-group">
                                    <div class="col-sm-12">
                                        <asp:Button CssClass="btn btn-info pull-right" runat="server" ID="enrollButton" Text="Enroll" OnClick="enrollButton_Click"/>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptContent" runat="server">
    <script src="../Bootstrap/js/Custom.js"></script>
</asp:Content>
