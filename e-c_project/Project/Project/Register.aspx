<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Project.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }

        .auto-style2 {
            width: 358px;
        }
        /* styles.css */
        .box {
            position: fixed;
            top: 0;
            transform: rotate(80deg);
            left: 0;
        }

        .wave {
            position: absolute;
            opacity: 0.4;
            width: 1500px;
            height: 1300px;
            margin-left: -150px;
            margin-top: -250px;
            border-radius: 43%;
        }

            .wave.-one {
                animation: rotate 7000ms infinite linear;
                opacity: 0.1;
                background: #0af;
            }

            .wave.-two {
                animation: rotate 3000ms infinite linear;
                opacity: 0.1;
                background: black;
            }

            .wave.-three {
                animation: rotate 7500ms infinite linear;
                background-color: #77daff;
            }

        @keyframes rotate {
            from {
                transform: rotate(0deg);
            }

            to {
                transform: rotate(360deg);
            }
        }


        body {
            font-family: Arial, sans-serif;
            background-color: #003791; /* PlayStation blue */
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            margin: 0;
        }

        .login-container {
            background-color: #fff;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
            text-align: center;
        }

        h1 {
            color: #003791;
            font-size: 24px;
            margin-bottom: 20px;
        }

        .input-field {
            width: 50%;
            padding: 10px;
            margin-bottom: 15px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        .login-button {
            background-color: #003791;
            color: #fff;
            border: none;
            border-radius: 5px;
            padding: 10px 20px;
            cursor: pointer;
            transition: background-color 0.3s;
        }

            .login-button:hover {
                background-color: #00256b; /* Slightly darker blue on hover */
            }
    </style>
</head>
<body>
    <form id="formLogin" runat="server">
        <div class="login-container">

            <img src="images/1200px-PlayStation_logo_and_wordmark.svg.png" width="600px" height="118px;" />
            <h1>Register</h1><br />
            <asp:Label ID="lblDisplay" runat="server" Text="Label" ForeColor="Red" Visible="False"></asp:Label><br />
            <asp:TextBox ID="txtUsername" runat="server" placeholder="Username" CssClass="input-field" required></asp:TextBox>
            <asp:TextBox ID="Email" runat="server" placeholder="Email" CssClass="input-field" required></asp:TextBox><br />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please enter valid email" ControlToValidate="Email" Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator><br />
            <asp:TextBox ID="txtPassword" runat="server" placeholder="Password" TextMode="Password" CssClass="input-field" required></asp:TextBox>
            <asp:TextBox ID="conPassword" runat="server" placeholder="Confirm Password" TextMode="Password" CssClass="input-field" required></asp:TextBox><br />
            <asp:CompareValidator runat="server" ErrorMessage="Password dosen't match" ControlToValidate="conPassword" ForeColor="Red" SetFocusOnError="True" ControlToCompare="txtPassword"></asp:CompareValidator><br />
            <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="login-button" OnClick="btnLogin_Click" /><br />
            Already have an account?  <a href="Login.aspx">Register Here</a>
            
            <div class="box">
                <div class="wave -one"></div>
                <div class="wave -two"></div>
                <div class="wave -three"></div>
            </div>
        </div>
    </form>
</body>
</html>