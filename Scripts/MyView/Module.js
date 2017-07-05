var row_data = new Object();
var data = {};
$(function () {


    //1.初始化Table
    var oTable = new TableInit();
    oTable.Init();

    $("#test").click(function (e) {
        $('#form').data('bootstrapValidator').resetForm(true);
    });
    //验证
    //var ovalidator = new validatorInit();
    //ovalidator.Init();
    $('#form').bootstrapValidator({
        message: 'This value is not valid',
        feedbackIcons: {
            valid: 'fa fa-check',
            invalid: 'fa fa-remove',
            validating: 'fa fa-refresh'
        },
        excluded: [':disabled'],
        fields: {
            Name: {
                message: '名称无效!',
                validators: {
                    notEmpty: {
                        message: '名称不能为空!'
                    },
                    stringLength: {
                        min: 1,
                        max: 20,
                        message: '字符长度1-20!'
                    }
                }
            },
            Code: {
                message: '编码无效!',
                validators: {
                    notEmpty: {
                        message: '编码不能为空!'
                    },
                    stringLength: {
                        min: 1,
                        max: 20,
                        message: '字符长度1-20!'
                    }
                }
            },
            OrderSort: {
                validators: {
                    notEmpty: {
                        message: '不能为空!'
                    },
                    regexp: {
                        regexp: /^[0-9]+$/,
                        message: '只能由数字组成!'
                    }
                }
            }
        }
    });

    $.post("/Module/Get_ParentModules", {}, function (result) {
        if (result.Msg == "成功")
        {
            $.each(result.data, function (i, n) {
                $("#txt_ParentModule").append("<option value='" + n.Id + "'>" + n.Name + "</option>");
            });
        }
    });
    //2.初始化Button的点击事件
    var oButtonInit = new ButtonInit();
    oButtonInit.Init();

});

var validatorInit = function () {
    var ovalidator = new Object();
    ovalidator.Init = function () {

    }
}

$("#btn_closefrom").click(function (e) {
    $('#form').data('bootstrapValidator').resetForm(true);
});

var TableInit = function () {
    var oTableInit = new Object();
    //初始化Table
    oTableInit.Init = function () {
        $('#tb_departments').bootstrapTable({
            url: '/Module/Get_Parent_Module',   //请求后台的URL（*）
            method: 'post',                     //请求方式（*）
            toolbar: '#toolbar',                //工具按钮用哪个容器
            striped: true,                      //是否显示行间隔色
            cache: false,                       //是否使用缓存，默认为true，所以一般情况下需要设置一下这个属性（*）
            pagination: true,                   //是否显示分页（*）
            sortable: true,                     //是否启用排序
            sortOrder: "asc",                   //排序方式
            queryParams: oTableInit.queryParams,//传递参数（*）
            sidePagination: "server",           //分页方式：client客户端分页，server服务端分页（*）
            pageNumber: 1,                      //初始化加载第一页，默认第一页
            pageSize: 15,                       //每页的记录行数（*）
            pageList: [15, 25, 50, 100],        //可供选择的每页的行数（*）
            search: true,                       //是否显示表格搜索，此搜索是客户端搜索，不会进服务端，所以，个人感觉意义不大
            strictSearch: true,
            showColumns: true,                  //是否显示所有的列
            showRefresh: true,                  //是否显示刷新按钮
            minimumCountColumns: 2,             //最少允许的列数
            clickToSelect: true,                //是否启用点击选中行
            height: 500,                        //行高，如果没有设置height属性，表格自动根据记录条数觉得表格高度
            uniqueId: "Id",                     //每一行的唯一标识，一般为主键列
            showToggle: true,                   //是否显示详细视图和列表视图的切换按钮
            cardView: false,                    //是否显示详细视图
            detailView: true,                   //是否显示父子表
            columns: [{
                radio: true
            }, {
                field: 'Name',
                title: '模块(菜单)名称',
                sortable: true
            },
            {
                field: 'Code',
                title: '编码',
                sortable: true
            }, {
                field: 'ParentId',
                visible: false
            }, {
                field: 'ParentName',
                title: '上级模块',
                sortable: true
            }
            , {
                field: 'Icon',
                title: '图标',
                sortable: true
            }, {
                field: 'Controller',
                title: 'Controller',
                sortable: true
            }
            , {
                field: 'Action',
                title: 'Action',
                sortable: true
            }, {
                field: 'OrderSort',
                title: '排序',
                sortable: true
            }, {
                field: 'IsMenu',
                title: '是否菜单',
                sortable: true
            }, {
                field: 'Enabled',
                title: '是否激活',
                sortable: true
            }],
            //注册加载子表的事件。注意下这里的三个参数！
            onExpandRow: function (index, row, $detail)
            {
                oTableInit.InitSubTable(index, row, $detail);
            },
            onClickRow: function (row, $element) {

                //$element.addClass("intro").siblings().removeClass('intro').end();//去除其他项的高亮形式
            },
            onCheck: function (row)
            {
                row_data = row;
                $("#tb_departments tr").removeClass('selected').end();
                $element.addClass("selected");
            }
        });
    };
    //得到查询的参数
    oTableInit.queryParams = function (params) {
        var temp = {   //这里的键的名字和控制器的变量名必须一直，这边改动，控制器也需要改成一样的
            limit: params.limit,   //页面大小
            offset: params.offset,  //页码
            departmentname: $("#txt_search_departmentname").val(),
            statu: $("#txt_search_statu").val()
        };
        return temp;
    };

    //初始化子表格(无限循环)
    oTableInit.InitSubTable = function (index, row, $detail) {
        var arrmenuid = [];
        var parentid = row.Id;
        var cur_table = $detail.html('<table></table>').find('table');
        $(cur_table).bootstrapTable({
            url: '/Module/Get_Child_Module',
            method: 'post',
            detailView: true,//父子表
            sidePagination: "server",
            queryParams: { strParentID: parentid },
            clickToSelect: true,
            uniqueId: "Id",
            pageSize: 5,
            pageList: [10, 25, 50, 100],
            columns: [{
                radio: true
            }, {
                field: 'Name',
                title: '模块(菜单)名称',
                sortable: true
            },
            {
                field: 'Code',
                title: '编码',
                sortable: true
            }, {
                field: 'ParentId',
                visible: false
            }, {
                field: 'ParentName',
                title: '上级模块',
                sortable: true
            }
            , {
                field: 'Icon',
                title: '图标',
                sortable: true
            }, {
                field: 'Controller',
                title: 'Controller',
                sortable: true
            }
            , {
                field: 'Action',
                title: 'Action',
                sortable: true
            }, {
                field: 'OrderSort',
                title: '排序',
                sortable: true
            }, {
                field: 'IsMenu',
                title: '是否菜单',
                sortable: true
            }, {
                field: 'Enabled',
                title: '是否激活',
                sortable: true
            }],
            //无线循环取子表，直到子表里面没有记录
            onExpandRow: function (index, row, $Subdetail) {
                oTableInit.InitSubTable(index, row, $Subdetail);
            },
            onClickRow: function (row, $element) {

            },
            onCheck: function (row) {
                row_data = row;
                $("#tb_departments tr").removeClass('selected').end();
                $element.addClass("selected");
            }
        });
    };

    return oTableInit;
};

function GetParentModule()
{

}
var ButtonInit = function () {
    var oInit = new Object();
    var postdata = {};

    oInit.Init = function () {
        
        $("#btn_add").click(function () {
            $('#form').data('bootstrapValidator').resetForm(true);
            $("#chk_Enabled").prop("checked", true);
            $("#myModalLabel").text("新增");
            $("#myModal").find(".form-control").val("");
            GetParentModule();
            $('#myModal').modal();
            postdata.Id = "-1";
        });

        $("#btn_SetButton").click(function () {
            $("#checkbox_content span").remove();
            $.post("/Module/Get_Roles", {ModuleId : row_data.Id}, function (result) {
                if (result.Msg == "成功") {
                    $.each(result.data, function (i, n) {
                        var str;
                        if (n.IsChecked == 0)
                            $("#checkbox_content").append("<span style='display:inline-block;width:120px;'><label style='display: block; padding-left: 15px; text-indent: -15px;'><input type='checkbox' id='" + n.Id + "'> " + n.Name);
                        else
                            $("#checkbox_content").append("<span style='display:inline-block;width:120px;'><label style='display: block; padding-left: 15px; text-indent: -15px;'><input type='checkbox' checked='checked' id='" + n.Id + "'> " + n.Name);
                    });
                    $('#myModal2').modal();
                }
            });
        });

        $("#btn_edit").click(function () {
            $('#form').data('bootstrapValidator').resetForm(true);
            $("#myModalLabel").text("编辑");
            $("#txt_Name").val(row_data.Name);
            $("#txt_Code").val(row_data.Code);
            $("#txt_Icon").val(row_data.Icon);
            $("#txt_ParentModule").val(row_data.ParentId);
            $("#txt_Controller").val(row_data.Controller);
            $("#txt_OrderSort").val(row_data.OrderSort);
            $("#txt_Action").val(row_data.Action);
            $("#chk_IsMenu").prop("checked", row_data.IsMenu);
            $("#chk_Enabled").prop("checked", row_data.Enabled);
            postdata.Id = row_data.Id;
            $('#myModal').modal();
        });

        $("#btn_delete").click(function () {
            //var arrselections = $("#tb_departments").bootstrapTable('getSelections');
            if (row_data == null) {
                toastr.warning('请选择有效数据');
                return;
            }
            bootbox.confirm({
                title: "删除",
                message: "确认要删除选择的数据吗？",
                buttons: {
                    confirm: {
                        label: '是',
                        className: 'btn-success'
                    },
                    cancel: {
                        label: '否',
                        className: 'btn-danger'
                    }
                },
                callback: function (result) {
                    if (result) {
                        $.ajax({
                            type: "post",
                            url: "/Module/Del",
                            data: { "data": JSON.stringify(row_data) },
                            success: function (data, status) {
                                if (status == "success") {
                                    $('#myModal').modal('hide');
                                    toastr.success('删除数据成功.');
                                    $("#tb_departments").bootstrapTable('refresh');
                                } else {
                                    $('#myModal').modal('hide');
                                    toastr.success('删除失败(1).');
                                }
                            },
                            error: function () { toastr.error('删除失败(2).'); },
                            complete: function () { }
                        });
                    }
                }
            });

        });

        $("#btn_submit").click(function () {
            $('#form').data('bootstrapValidator').validate();
            var isVal = $("#form").data('bootstrapValidator').isValid();
            if (!isVal) { return; }
            postdata.Name = $("#txt_Name").val();
            postdata.Code = $("#txt_Code").val();
            postdata.Icon = $("#txt_Icon").val();
            postdata.ParentId = $("#txt_ParentModule").val();
            postdata.Controller = $("#txt_Controller").val();
            postdata.OrderSort = $("#txt_OrderSort").val();
            postdata.Action = $("#txt_Action").val();
            postdata.IsMenu = $('#chk_IsMenu').prop('checked');
            postdata.Enabled = $('#chk_Enabled').prop('checked');
            $.ajax({
                type: "post",
                url: "/Module/GetEdit",
                data: { "data": JSON.stringify(postdata) },
                success: function (data, status) {
                    if (status == "success") {
                        $('#myModal').modal('hide');
                        toastr.success('提交数据成功');
                        $("#tb_departments").bootstrapTable('refresh');
                    }
                },
                error: function () { toastr.error('提交失败'); },
                complete: function () { }
            });
        });

        $("#btn_SetButton_submit").click(function () {
            var data = [];
            $("#checkbox_content input:checkbox").each(function (i, n) {
                if ($(n).prop('checked') == true)
                {
                    data.push($(n).attr("id"));
                }
            });
            
            $.ajax({
                type: "post",
                url: "/Module/Sub_ModulePermission",
                data: { "data": JSON.stringify(data), "ModuleId": row_data.Id },
                success: function (data, status) {
                    if (status == "success") {
                        $('#myModal').modal('hide');
                        toastr.success('提交数据成功');
                    }
                },
                error: function () { toastr.error('提交失败'); },
                complete: function () { }
            });

        });
        
        $("#btn_query").click(function () {
            $("#tb_departments").bootstrapTable('refresh');
        });
    };

    return oInit;
};