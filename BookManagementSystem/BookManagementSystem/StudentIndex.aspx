<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentIndex.aspx.cs" Inherits="StudentIndex" %>
<!DOCTYPE html>
<html>
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>学生管理</title>
    <meta name="viewport" content="initial-scale=1, maximum-scale=1">
    <link rel="shortcut icon" href="/favicon.ico">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">

    <link rel="stylesheet" href="//g.alicdn.com/msui/sm/0.6.2/css/sm.min.css">
    <link rel="stylesheet" href="//g.alicdn.com/msui/sm/0.6.2/css/sm-extend.min.css">

  </head>
  <body runat="server">
    <div class="page-group">
        <div class="page page-current">
            <!-- 标题栏 -->
            <header class="bar bar-nav">
                <a class="icon icon-me pull-left open-panel"></a>
                <h1 class="title">功能</h1>
            </header>

            <!-- 这里是页面内容区 -->
            <div class="content">
              <div class="buttons-tab">
                <a href="#tab1" class="tab-link active button">借阅管理</a>
                <a href="#tab2" class="tab-link button">个人以借书籍管理</a>
                <a href="#tab3" class="tab-link button">个人账单管理</a>
              </div>
              <form runat="server">
                  <div class="content-block">
                    <div class="tabs">
                        <!--书籍管理页面-->
                      <div id="tab1" class="tab active">
                        <div class="content-block">
                            <!--类别下拉列表-->
                            <asp:DropDownList ID="DropDownList1" runat="server">                            
                            </asp:DropDownList>
                            <!---->
                            <asp:DropDownList ID="DropDownList2" runat="server">
                                <asp:ListItem>只显示在馆书籍</asp:ListItem>
                                <asp:ListItem>全部显示</asp:ListItem>
                            </asp:DropDownList>

                            <asp:TextBox ID="TextBox1" runat="server" placeholder="根据作者模糊查询">

                            </asp:TextBox>
                            <asp:TextBox ID="TextBox2" runat="server" placeholder="根据书籍名称模糊查询">

                            </asp:TextBox>
                            <asp:TextBox ID="TextBox3" runat="server" placeholder="根据出版社模糊查询">

                            </asp:TextBox>
                            <asp:TextBox ID="TextBox4" runat="server" placeholder="根据书籍编号精确查询">

                            </asp:TextBox>


                            <!--筛选按钮-->
                            <asp:Button ID="Button1" runat="server" Text="根据需求筛选" OnClick="FilterBooks"/>

                            <table>
                                <thead>
                                    <tr>
                                        <th>图书编号</th>
                                        <th>图书名称</th>
                                        <th>图书作者</th>
                                        <th>图书出版社</th>
                                        <th>在馆数量</th>
                                        <th>图书类别</th>
                                    </tr>
                                </thead>
                                <asp:Repeater ID="Repeater1" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#Eval("b_id") %></td>
                                            <td><%#Eval("b_name") %></td>
                                            <td><%#Eval("b_author") %></td>
                                            <td><%#Eval("b_press") %></td>
                                            <td><%#Eval("b_num") %></td>
                                            <td><%#Eval("sort_name") %></td>                                     
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                          
                            <p>This is tab 2 content</p>
                        </div>
                      </div>
                      <div id="tab2" class="tab">
                        <div class="content-block">
                            <!--搜索栏-->
                            <div class="bar bar-header-secondary">
                              <div class="searchbar">
                                <a class="searchbar-cancel">取消</a>
                                <div class="search-input">
                                  <label class="icon icon-search" for="search"></label>
                                  <input type="search" id='search' placeholder='输入关键字...'/>
                                </div>
                              </div>
                            </div>
                            <br />
                            <br />
                            <div>
                                

                                    <asp:GridView ID="GridView1" runat="server"></asp:GridView>                           
                            </div>                          
                        </div>
                      </div>
                      <div id="tab3" class="tab">
                        <div class="content-block">
                            <table>
                                <thead>
                                    <tr>
                                        <th>学生学号</th>
                                        <th>所欠书籍名称</th>
                                        <th>以超期时间</th>
                                        <th>欠费金额</th>
                                    </tr>
                                </thead>
                                <asp:Repeater ID="Repeater2" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#Eval("st_id") %></td>
                                            <td><%#Eval("b_name") %></td>
                                            <td><%#Eval("over_date") %></td>
                                            <td><%#Eval("fine") %></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>

                          <p>This is tab 2 content</p>
                        </div>
                      </div>
                    </div>
                </div>
              </form>
            </div>
         </div>
    </div>
       
    <!-- popup, panel 等放在这里 -->
    <div class="panel-overlay"></div>
    <!-- Left Panel with Reveal effect -->
    <div class="panel panel-left panel-reveal">
        <div class="content-block">
            <p>这是一个侧栏</p>
            <p></p>
            <!-- Click on link with "close-panel" class will close panel -->
            <p><a href="#" class="close-panel">关闭</a></p>
        </div>
    </div>
    <script type='text/javascript' src='//g.alicdn.com/sj/lib/zepto/zepto.min.js' charset='utf-8'></script>
    <script type='text/javascript' src='//g.alicdn.com/msui/sm/0.6.2/js/sm.min.js' charset='utf-8'></script>
    <script type='text/javascript' src='//g.alicdn.com/msui/sm/0.6.2/js/sm-extend.min.js' charset='utf-8'></script>

  </body>
</html>
