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
                <a href="#tab1" class="tab-link active button">以借书籍管理</a>
                <a href="#tab2" class="tab-link button">借阅管理</a>
                <a href="#tab3" class="tab-link button">个人账单管理</a>
              </div>
              <div class="content-block">
                <div class="tabs">
                    <!--书籍管理页面-->
                  <div id="tab1" class="tab active">
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
                            <form runat="server">
                                <asp:GridView ID="GridView1" runat="server"></asp:GridView>
                            </form>
                        </div>                          
                    </div>
                  </div>
                  <div id="tab2" class="tab">
                    <div class="content-block">
                      <p>This is tab 2 content</p>
                    </div>
                  </div>
                  <div id="tab3" class="tab">
                    <div class="content-block">
                      <p>This is tab 2 content</p>
                    </div>
                  </div>

                </div>
              </div>
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
