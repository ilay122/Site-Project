<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="contact.aspx.cs" Inherits="PEGS.contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        
        var msg = "";
        function validPhone(phone){
            var length = phone.length;
            if (phone.charAt(0) == 0 && length == 10 && !isNaN(phone))
                return true;
            else
                return false;
        }
        function validId(str) {
            var length = str.length;
            if (length == 9)
                return true;
            else
                return false;
        }
        function validEmail(str) {
            if ((str.split("@").length == 2) &&
                (str.indexOf("@") != 0) &&
                str.indexOf("." != 0) &&
                (str.lastIndexOf(".") != str.length - 1)
                )
                return true;
            else
                return false;
        }
        function validName(name) {
            if (isNaN(name))
                return true;
            else
                return false;
        }
        function checkForm() {
            
            if (!validPhone(document.getElementById("phone").value))
                msg += "<li>PHONE MUST HAVE NUMBERS ONLY OR/AND LENGTH INCORRECT </li>";
            if (!validEmail(document.getElementById("email").value))
                msg += "<li> NOT VALID EMAIL</li>";
            if (!validName(document.getElementById("firstName").value))
                msg += "<li>FIRST NAME HAS DIGITS </li>";
            if (!validName(document.getElementById("lastName").value))
                msg += "<li>LAST NAME HAS DIGITS </li>";
            if (!validId(document.getElementById("idNum").value))
                msg+="<li>INVALID ID MUST CONTAIN ONLY NUMBERS</li>"

            if (msg.length == 0)
                return true;
            else
            {
                document.getElementById('errors').innerHTML = msg;
                msg = "";
                return false;
            }
        }
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <ul id="errors"></ul>
        <%=serverMsg %>
        
            <form action="" name="register" id="register" method="post"  onsubmit="return checkForm();">
                <table>
                    <tr>
                        <td>ID number:</td>
                        <td><input type="text" name="idNum" placeholder="put your ID here"  id="idNum" required autocomplete="off" maxlength="9"/></td>
                    </tr>
                    <tr>
                        <td>Password </td>
                        <td><input type="password" name="password" placeholder="password here" required autocomplete="off" /></td>
                    </tr>
                    <tr>
                        <td>First Name </td>
                        <td><input type="text" name="firstName" placeholder="First name" id="firstName" required  autocomplete="off"/></td>
                    </tr>
                    <tr>
                        <td> Last name </td>
                        <td><input type="text" name="lastName" placeholder="Last name" id="lastName" required  autocomplete="off"/></td>
                    </tr>
                    <tr>
                        <td>Gender </td>
                        <td>
                             <select name="gender" id="gender">
                               <option value="male">Male</option>
                               <option value="female">Female</option>
                             </select>
                        </td>
                    </tr>
                    <tr>
                        <td> Phone number </td>
                        <td><input type="text" name="phone" placeholder="phone number" required autocomplete="off" id="phone" maxlength="10"/></td>
                    </tr>
                    <tr>
                        <td>Email adress</td>
                        <td><input type="text" name="email" placeholder="email" required autocomplete="off" id="email" /></td>
                    </tr>
                    <tr>
                        <td>Adress</td>
                        <td><input type="text" name="adress" placeholder="adress" required autocomplete="off" id="adress" /></td>
                    </tr>
                    <tr>
                        <td><input type="submit" value="submit" class="tfbutton" name="submit" /></td>
                        <td><input type="reset" value="reset" class="tfbutton" /></td>
                    </tr>
                </table>
              
                
            </form>

        </div>
</asp:Content>
