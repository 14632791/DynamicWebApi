/***********************************
/* 修改人：xwf
/* 修改日期：2012-11-1
/*easyui框架页的一些常规js操作，如初始化菜单、新增tab
/*依赖：jquery.js,easyui.js
***********************************/
$(document).ready(function () {
    EasyuiMenu.initLeftMenu();
});
var EasyuiMenu = (function (mod) {
    //绑定右键菜单事件
    function tabConTextMenu() {
        //关闭当前
        $("#mm-tabclose").click(function () {
            var currtabTitle = $("#mm").data("currtab");
            $("#tabs").tabs("close", currtabTitle);
        });

        //全部关闭
        $("#mm-tabcloseall").click(function () {
            $(".tabs-inner").each(function (i, n) {
                var t = $(n).children(".tabs-closable").text();
                $("#tabs").tabs("close", t);
            });
        });

        //关闭除当前之外的TAB
        $("#mm-tabcloseother").click(function () {
            $("#mm-tabcloseright").click();
            $("#mm-tabcloseleft").click();
        });


        //关闭当前右侧的TAB
        $("#mm-tabcloseright").click(function () {
            var nextall = $(".tabs-selected").nextAll();
            if (nextall.length === 0) {
                //msgShow('系统提示','后边没有啦~~','error');
                //alert('后边没有啦~~');
                return false;
            }
            nextall.each(function (i, n) {
                var t = $("a:eq(0)", $(n)).children(".tabs-closable").text();
                $("#tabs").tabs("close", t);
            });
            return false;
        });


        //关闭当前左侧的TAB
        $("#mm-tabcloseleft").click(function () {
            var prevall = $(".tabs-selected").prevAll();
            if (prevall.length === 0) {
                //alert('到头了，前边没有啦~~');
                return false;
            }
            prevall.each(function (i, n) {
                var t = $("a:eq(0)", $(n)).children(".tabs-closable").text();
                $("#tabs").tabs("close", t);
            });
            return false;
        });

        //退出
        $("#mm-exit").click(function () {
            $("#mm").menu("hide");
        });

    }
     function tabCloseEven() {
            //双击关闭TAB选项卡
            $(".tabs-inner").dblclick(function () {
                var subtitle = $(this).children(".tabs-closable").text();
                $("#tabs").tabs("close", subtitle);
            });

            /*为选项卡绑定右键*/
            $(".tabs-inner").bind("contextmenu", function (e) {
                $("#mm").menu("show", {
                    left: e.pageX,
                    top: e.pageY
                });

                var subtitle = $(this).children(".tabs-closable").text();

                $("#mm").data("currtab", subtitle);
                $("#tabs").tabs("select", subtitle);
                return false;
            });
     }
     function addTab(subtitle, url) {
         var content = "<iframe scrolling=\"auto\" frameborder=\"0\"  src=\"" + url + "\" style=\"width:100%;height:99%;\"></iframe>";
         if ($("#tabs").tabs("exists", subtitle)) {
             $("#tabs").tabs("select", subtitle);
             var currTab = $("#tabs").tabs("getSelected");
             $("#tabs").tabs("update", {
                 tab: currTab,
                 options: {
                     content: content
                 }
             });
         } else {
             var tabLi = $("#tabs .tabs li");
             //当TAB个数达到15个时，则关闭最前面的第二个TAB
             if (tabLi.length === 15) {
                 $("#tabs").tabs("close", tabLi.eq(1).children(".tabs-inner").children(".tabs-closable").text());
             }

             $("#tabs").tabs("add", {
                 title: subtitle,
                 content: content,
                 closable: true
                 // icon:icon
             });
            
         }
     }
     function setSelectedClass(obj) {
         var div = $(obj).parent();
         //增加点击样式
         div.find("a").removeClass("muaselect");
             $(obj).children("a").addClass("muaselect");
     }
     function menuClick() {//菜单点击事件
         $("#west li").click(function () {
             var tabTitle = $(this).children("a").text();
             var url = $(this).children("a").attr("rel");
             addTab(tabTitle, url);
             setSelectedClass(this);
         });
         tabCloseEven();
         tabConTextMenu();
        }
       
        //初始化Tab与menu关联关系
        function tabSelect() {
            $("#tabs").tabs({
                onSelect: function (title) {
                    $.each($("#west li"), function (i, n) {
                        if ($(this).children("a").text() === title) {
                            setSelectedClass(this);
                            }
                    });
                    //防止点击其他TAB时出现光标闪烁或日期控件弹出之后没有关闭
                    var getTab = $("#tabs").tabs("getSelected");
                    var iframes = getTab.find("iframe");
                    if (iframes.length > 0) {
                        iframes.contents().find("body").focus();
                    }
                }
            });
        }
        //初始化左侧菜单
        function initLeftMenu() {
            menuClick();
           tabSelect();
            $("#north,#south").css("display", "block");
        }

        return {
        initLeftMenu: initLeftMenu
    };
})(window);


