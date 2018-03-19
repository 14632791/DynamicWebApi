/***********************************
/* 添加：xwf
/* 修改日期：2012-8-29
/*主要是是基于easyui.public.js的进一步业务精简和封装
/*依赖：easyui.public.js
***********************************/
$(function () {
    EasyuiBusiness.initTrStyle("trcls");
    EasyuiBusiness.checkAll("ckbAll", "ckbcls");
});

var EasyuiBusiness = (function (pub) {
    var containerId = "popContainer", iframeId = "popIframe";
  
    //初始化行样式
    function initTrStyle(className) {
        //添加列表隔行色
        $("." + className + ":odd").addClass("trodd");
    }

    //根据类名获取最后一项选择值
    function getLastCkbVals(className) {
        var ckbvals = [];
        $("." + className).each(function (i, n) {
            var checked = $(n).attr("checked");
            if (checked === "checked" || checked === true) {
                ckbvals.push($(n).val());
            }
        });
        if (ckbvals.length === 0)
            return "";
        return ckbvals.pop();
    }


    function validateMaxLength() {
        var max = $("textarea[maxlength]");
        //对超出长度的字符不再允许key入
        max.keypress(function (e) {
            var len = $(this).attr("maxlength");
            if (len > 0 && len <= this.value.length) {
                var k = window.event ? e.keyCode : e.which;
                if (k > 47) {
                    return false;
                }
            }
            return true;
        });
        //对其他方式输入【如中文输入法输入或键盘的ctrl+v】的长度进行截断
        max.keyup(function () {
            var len = $(this).attr("maxlength");
            if (len > 0 && len < this.value.length) {
                this.value = this.value.substring(0, len);
            }
        });
        //对粘贴时的长度进行截断，粘贴事件发生后，文本才真正被粘贴到目标控件上，所以这里稍微处理了一下
        max.bind("paste", function () {
            window.setTimeout("$('#" + this.id + "').trigger('keyup')", 10);
        });
    }
    //复选框全选,className类名
    function checkAll(id, className) {
        $("#" + id).click(function () {
            var checked = $(this).attr("checked");
            if (checked === "checked" || checked === true) {
                $("." + className).attr("checked", "checked");
            } else {
                $("." + className).removeAttr("checked");
            }
        });
    }
    //批量删除处理方法、主要是刷新在tab页内的列表
    function getCheckedRows(className) {
        var ckbvals = [];
        $("." + className).each(function (i, n) {
            var checked = $(n).attr("checked");
            if (checked === "checked" || checked === true) {
                ckbvals.push($(n).val());
            }
        });
        return ckbvals.join(",");
    }

    function batchDeleted(pUrl) {
        var items = getCheckedRows("ckbcls");
        if (!items) {
            pub.msgShow("批量删除", "当前没有选择删除项", "err");
        } else {
            pub.msgConfirm("批量删除", "确定要删除吗？", function () {
                var url;
                if (pUrl.indexOf("?") > 0) {
                    url = pUrl + "&id=" + items;
                } else {
                    url = pUrl + "/" + items;
                }

                pub.setIframeSrc(iframeId, url);
                pub.refreshTab();
            });
        }
    }
    //删除点击处理方法、主可以刷新在tab页内的列表
    function deleted(obj,id) {
        pub.msgConfirm("提示", "确定执行" + $("#" + obj).text() + "操作吗？", function () {
            var url = $("#" + obj).attr("href");
            if (url.indexOf("?") > 0) {
                url = url + "&id=" + id;
            } else {
                url = url + "/" + id;
            }
            pub.setIframeSrc(iframeId, url);
            pub.refreshTab();
            return true;
        });
        return false;
    }
    function viewForm() { //将表单页变为查看页
        $(":text,textarea").each(function () {
            $("<span>" + $(this).val() + "</span>").replaceAll(this);
        });
        $("select").attr("disabled", "disabled");
        $("select option:selected").each(function (i, n) {
            $("<span>" + $(n).text() + "</span>").replaceAll(n.parentNode);
        });
    }
   


    return {
        initTrStyle: initTrStyle,
        checkAll: checkAll,
        viewForm: viewForm,
        batchDeleted: batchDeleted,
        deleted: deleted
        
     
       
    };

})(top.EasyuiPublic);


