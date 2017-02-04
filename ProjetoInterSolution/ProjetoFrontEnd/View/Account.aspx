<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="ProjetoInter.View.Account" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style>
        #user {
            width: 50%;
            height: 50%;
            border: solid;
            top: 50%;
            left: 50%;
        }
    </style>
</head>
<body>
    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
        <br />
        <div class="settings-wrapper" id="pad-wrapper">

            <form id="account" runat="server" class="form-horizontal" role="form">
                <div class="row">
                    <!-- avatar column -->
                    <div class="col-xs-4 col-xs-offset-1 avatar-box">
                        <div class="personal-image">

                            <asp:Image runat="server" ID="user" CssClass="avatar img" alt="Avatar" />
                        </div>
                        <br />
                        <br />
                        <h4>Upload a different photo...</h4>
                        <br />
                        <asp:FileUpload ID="file" runat="server" class="form-control" />



                    </div>


                    <!-- edit form column -->
                    <div class=" col-xs-7 personal-info">

                        <h4>User info</h4>

                        <div class="form-group">
                            <label class="col-xs-2 control-label">Name:</label>
                            <div class="col-xs-8">
                                <asp:TextBox ID="txtName" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-xs-2 control-label">Default Email:</label>
                            <div class="col-xs-8">
                                <asp:DropDownList ID="selectDefaultEmail" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-xs-2 control-label">Login:</label>
                            <div class="col-xs-8">
                                <asp:TextBox ID="txtLogin" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-xs-2 control-label">Your Password:</label>
                            <div class="col-xs-8">
                                <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="form-control" />
                                <label id="lblPass" runat="server" visible="false" style="color: red"></label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-xs-2 control-label">New Password:</label>
                            <div class="col-xs-8">
                                <asp:TextBox ID="txtNewPassword" TextMode="Password" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-xs-2 control-label">Confirm password:</label>
                            <div class="col-xs-8">
                                <asp:TextBox ID="txtConfirmPassword" TextMode="Password" runat="server" CssClass="form-control" />
                                <label id="passConf" runat="server" visible="false" style="color: red"></label>
                            </div>
                        </div>
                        <div class="actions col-xs-offset-7">
                            <asp:Button ID="Cancel" runat="server" Text="Cancel" CssClass="btn btn-md btn-danger" OnClick="Cancel_Click" />
                            <asp:Button ID="Save" runat="server" Text="Save" CssClass="btn btn-md btn-success" OnClick="Save_Click" />
                        </div>

                    </div>
                </div>

            </form>
        </div>
    </div>

</body>
</html>
