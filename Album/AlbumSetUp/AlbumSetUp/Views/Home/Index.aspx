<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<AlbumSetUp.Models.ListingClass>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

  <div id="list">
  <div id="abumist">
    <table>
    <thead>
    <tr>
    <td>Thump nail</td>
    <td>Tite</td>
     <td>Name</td>
      <td>Email</td>
       <td>Phone</td>
    </tr>
    </thead>
    
    <tbody>
     <%foreach (var item in Model){%>
     <tr>
     <td><img src='<%=item.firstthumpnail%>' /></td>
            <td><a onclick="showdetais(<%=item.abumid %>)"><%=item.title %></a></td>
              <td><a onclick="showuserdetais(<%=item.userid %>)"><%=item.username %></a></td>
                <td><%=item.email %></td>
                  <td><%=item.phone %></td>

            
            </tr>
        <%} %>  
    
    </tbody>
    </table>
    </div>
    <table>
    <tr>
       
       <td><a id="1" onclick="shownextpage(1)">1</a></td> 
       <td><a id="10" onclick="shownextpage(10)">2</a></td>
       <td><a id="20" onclick="shownextpage(20)">3</a></td> 
       <td><a id="30" onclick="shownextpage(30)">4</a></td> 
       <td><a id="40" onclick="shownextpage(40)">5</a></td> 
       <td><a id="50" onclick="shownextpage(50)">6</a></td> 
       <td><a id="60" onclick="shownextpage(60)">7</a></td> 
       <td><a id="70" onclick="shownextpage(70)">8</a></td> 
       <td><a id="80" onclick="shownextpage(80)">9</a></td> 

          <td><a id="90"  onclick="shownextpage(90)">10</a></td> 
      
    </tr>
    </table>
    </div>
    <input type='button' id='hidedetail' onclick='HideDetais()' value='Back to List' style="display:none" />
    <div id="details">
    
    </div>
     <input type='button' id='hideuserdetail' onclick='HideDetais()' value='Back to List' style="display:none" />
    
    <div id="userdetais">
    
    </div>
    <div id="postdetais">
    
    </div>

    <script type="text/javascript">

        function shownextpage(id) {
            $("#" + id).parent().attr("background-color", "blue")
        $.ajax({
            url: "/Home/shownextpage",
            type: "get",
            data: { page: id }
            , success: function (result) {
                debugger;
                var str = "<table>    <thead>    <tr>    <td>Thump nail</td>    <td>Tite</td>     <td>Name</td>      <td>Email</td>       <td>Phone</td>    </tr>    </thead>      <tbody>";
                for (var i = 0; i < result.length; i++) {
                    var str = str + " <tr><td><img src='" + result[i].firstthumpnail + "' /></td>";
                    var str = str + " <td><a onclick='showdetais(" + result[i].abumid + ")'>" + result[i].title + "</a></td>";
                    var str = str + " <td><a onclick='showuserdetais(" + result[i].userid + ")'>" + result[i].username + "</a></td>";
                    var str = str + " <td>" + result[i].email + "</td>";
                    var str = str + " <td>" + result[i].phone + "</td></tr>";
                }

                var str = str + "</tbody></table>";

                $("#abumist").html("");
                $("#abumist").html(str);
            }
        });
      }
       
//        $(document).ready(function () {
//            $.ajax({
//                type: "GET",
//                url: "/Home/getallalbum",
//                contentType: "application/json; charset=utf-8",
//                data: "{}",
//                datatype: 'json',
//                timeout: 10000,
//                success: function (data) {
//                    debugger;
//                    alert(data.Results[0].Company);
//                }
//            });
        //        });
        function ShowPosts(id) {
            $("#postdetais").show()
            $.ajax({
                url: "/Home/GetPostByUserId",
                type: "get",
                data: { userid: id }
            , success: function (result) {
                debugger;
                var str = "<table><tr><td>Tite</td><td>Post</td></tr>";
                for (var i = 0; i < result.length; i++) {
                    var str = str + "<tr><td align='center'><b>" + result[i].title + ":</b></td><td>" + result[i].body + "</td></tr>"
                   
                }
                str = str + "</table>";


                $("#postdetais").html(str);
            }
            });
        }
        function HideDetais() {
            $("#list").show();
            $("#details").hide();
            $("#userdetais").hide();
            $("#hideuserdetail").hide();
            $("#hidedetail").hide();

            $("#postdetais").hide();

        }
        function showuserdetais(id) {
            $("#userdetais").html("");
            $("#list").hide();
            $("#userdetais ").show();
            $("#hidedetail").show();
            $.ajax({
                url: "/Home/getallalbum",
                type: "get",
                data: { userid: id }
            , success: function (result) {
                debugger;
                var data = $.parseJSON(result);
                var str = "<table>";

                var str = str + "<tr><td align='center'><b>Name:</b></td><td>" + data[0].name + "</td></tr>"
                str = str + "<tr><td align='center'><b>User Name:</b></td><td>" + data[0].username + "</td></tr>"
                str = str + "<tr><td align='center'><b>Email:</b></td><td>" + data[0].email + "</td></tr>"
                str = str + "<tr><td align='center'><b>Phone:</b></td><td>" + data[0].phone + "</td></tr>"
                str = str + "<tr><td align='center'><b>Address:</b></td><td>" + data[0].address.street + ',' + data[0].address.suite + ',' + data[0].address.city + ',' + data[0].address.zipcode + ', lat:' + data[0].address.geo.lat + ', ng:' + data[0].address.geo.lng + "</td></tr>"
                str = str + "<tr><td align='center'><b>Phone:</b></td><td>" + data[0].website + "</td></tr>"
                str = str + "<tr><td align='center'><b>Comapany:</b></td><td>" + data[0].company.name + ',' + data[0].company.catchPhrase + ',' + data[0].company.bs + "</td></tr>"
               
                str = str + "<td><a onclick='ShowPosts(" + data[0].id + ")'>Show Posts</a></td>"
                str = str + "</table>";


                $("#userdetais").html(str);
            }
            });
        }
        function showdetais(id) {
            $("#details").html("");
            $("#list").hide();
            $("#details").show();
            $("#hidedetail").show();
            $.ajax({
                url: "/Home/GetAlbumDetaisById",
                type: "get",
                data: { AbumId: id }
            , success: function (result) {
                debugger;
                var ht = "<table><tr>";
                for (var i = 0; i < result.length; i++) {
                    if (i <= 4) {
                        var str = str + "<td align='center'><img src='" + result[i].thumbnailUrl + "'/></br>" + result[i].title + "</td>";
                    }
                    else if (i == 5) {
                        str = str + "</tr><tr>";
                    }
                    else {
                        var str = str + "<td align='center'><img src='" + result[i].thumbnailUrl + "'/></br>" + result[i].title + "</td>";
                    }
                }
                ht = ht + str + "</tr></table>";
                $("#details").html(ht);
            }
            });

        }
    </script>
</asp:Content>

