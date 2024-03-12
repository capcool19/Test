<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Project.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
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
            <h1>Login</h1>
            <br />
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="False" Text=""></asp:Label>
            <br />
            <asp:TextBox ID="txtUsername" runat="server" placeholder="Username" CssClass="input-field" required></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtUsername" Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
            <asp:TextBox ID="txtPassword" runat="server" placeholder="Password" TextMode="Password" CssClass="input-field" required></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtPassword" Display="Dynamic" EnableTheming="False" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator><br />
            Not yet a user ? <a href="Register.aspx">Register Here</a>
            <br />
            <br />
            <asp:Button ID="btnLogin" runat="server" Text="Log In" CssClass="login-button" OnClick="btnLogin_Click" /><br />
            <div class="box">
                <div class="wave -one"></div>
                <div class="wave -two"></div>
                <div class="wave -three">
                    
                </div>
            </div>
        </div>
    </form>
</body>
</html>
