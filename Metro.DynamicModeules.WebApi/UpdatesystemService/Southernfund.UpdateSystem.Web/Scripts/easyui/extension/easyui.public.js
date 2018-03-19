/***********************************
/* 添加：xwf
/* 修改日期：2013-4-21
/*主要是框架页的一些常规js工具方法，如弹出层操作、控制页面刷新
/*依赖：easyui.js
***********************************/

var EasyuiPublic = (function (mod) {
    var containerId = "popContainer", iframeId = "popIframe";
    //等待加载效果
    function loadpage(b) {
        if (b === 100) {
            $(".datagrid-mask,.datagrid-mask-msg").hide();
        } else {
            $("<div class=\"datagrid-mask\" style=\"background:#000000\"></div>").css({ display: "block", width: "100%", height: $(window).height() }).appendTo("body");
            $("<div class=\"datagrid-mask-msg\" style=\"border:1px\"></div>").html("正在加载，请稍候……").appendTo("body").css({ display: "block", left: ($(document.body).outerWidth(true) - 190) / 2, top: ($(window).height() - 45) / 2 });
        }
    }
 
    //刷新显示的tab页 add by xwf on 2012-11-10
    function getFrameDocument(frame) {
        return frame && typeof (frame) == "object" && frame.contentDocument || frame.contentWindow && frame.contentWindow.document || frame.document;
    }

    function refreshTab() {
        getFrameDocument($("#tabs div .panel :visible iframe")[0]).location.reload(true);
    }
   
  
    //弹出信息窗口 title:标题 msgString:提示信息 msgType:信息类型 [error,info,question,warning]
    function msgShow(title, msgString) {
        $.messager.show({
            title: title,
            msg: msgString,
            timeout: 500,
            showType: "show",
            style: {
                right: "",
                bottom: ""
            }
        });
    }
    //main页中单个表单提交提示方法,通过刷新改变路由转向
    function formMsg(msg, url) {
            msgShow("提示", msg);
            location.href = url;
    }

    //确定信息,改名避免与百度富文本冲突
    function msgConfirm(title, message, fun) {
        $.messager.confirm(title, message, function (isOk) {
            if (isOk) {
                fun();
            }
        });
    }

    function getUrlRefresh(url) {
        if (url.indexOf("?") > 0) {
            var reg = /&t=.+?(?=&|$)/;
            var m = url.match(reg);
            if (m) {
                return url.replace(reg, "&t=" + (new Date().getTime()));
            } else {
                return url + "&t=" + (new Date().getTime());
            }

        } else {
            return url + "?t=" + (new Date().getTime());
        }
    }

    function setIframeSrc(id, url) {
        $("#" + id).attr("src", url);
    }
    //popContainer为页面div的id，popIframe为崁入div中的iframe的Id,event为事件对象预留做附加处理用
    function openDialog(pUrl, pWidth, pHeight, pTitle, icon) {
        var settings = {
            title: pTitle,
            width: pWidth,
            height: pHeight,
            iconCls: icon,
            closed: false,
            cache: false,
            modal: true
        };
        $("#" + iframeId).attr("src", pUrl);
        $("#" + containerId).dialog(settings);
    }

    function getViewportWidth() {
        if (window.innerWidth !== window.undefined)//FF
            //return window.innerWidth-offset; 
            return window.innerWidth - 30;
        if (document.compatMode === "CSS1Compat")//IE
            return document.documentElement.clientWidth - 30;
        if (document.body)//other
            return document.body.clientWidth - 30;
        return 640;
    }

    function getViewportHeight() {
        if (window.innerHeight !== window.undefined)//FF
            return window.innerHeight - 30;
        if (document.compatMode === "CSS1Compat")//IE
            return document.documentElement.clientHeight - 30;
        if (document.body)//other
            return document.body.clientHeight - 30;
        return 400;
    }
    //接近全屏的大窗口
    function openFullWindow(pUrl, pTitle, icon) {
        var settings = {
            title: pTitle,
            iconCls: icon,
            width: getViewportWidth(),
            height: getViewportHeight(),
            closed: false,
            cache: false,
            minimizable: false,
            maximizable: false,
            draggable: false,
            resizable: false,
            modal: true
        };
        settings = $.extend(settings, options);
        $("#" + iframeId).attr("src", pUrl);
        $("#" + containerId).window(settings);
    }

    //关闭对话框
    function closeDialog() {
        $("#" + iframeId + " form").form("clear");
        $("#" + iframeId).attr("src", "about:blank");
        $("#" + containerId).dialog("close");
    }
    //根据类名获取所有选择框值，逗号分隔
    function createMsg(msg) {
        if (msg !== "") {
            refreshTab();
            closeDialog(iframeId, containerId);
            msgShow("提示", msg);
        }
    }

    return {
        openDialog: openDialog,
        closeDialog: closeDialog,
        openFullWindow: openFullWindow,
        msgShow: msgShow,
        msgConfirm: msgConfirm,
        setIframeSrc: setIframeSrc,
        refreshTab: refreshTab,
        createMsg: createMsg
   
    };
})(window);
