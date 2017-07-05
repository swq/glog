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
            SortOrder: {
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
            url: '/Permission/GetPermission',         //请求后台的URL（*）
            method: 'post',                      //请求方式（*）
            toolbar: '#toolbar',                //工具按钮用哪个容器
            striped: true,                      //是否显示行间隔色
            cache: false,                       //是否使用缓存，默认为true，所以一般情况下需要设置一下这个属性（*）
            pagination: true,                   //是否显示分页（*）
            sortable: false,                     //是否启用排序
            sortOrder: "asc",                   //排序方式
            queryParams: oTableInit.queryParams,//传递参数（*）
            sidePagination: "server",           //分页方式：client客户端分页，server服务端分页（*）
            pageNumber: 1,                       //初始化加载第一页，默认第一页
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
            showToggle: true,                    //是否显示详细视图和列表视图的切换按钮
            cardView: false,                    //是否显示详细视图
            detailView: false,                   //是否显示父子表
            columns: [{
                title: '全选',
                checkbox: true
            }, {
                field: 'Name',
                title: '权限（按钮）名称',
                sortable: true
            },
            {
                field: 'Code',
                title: '编码',
                sortable: true
            }, {
                field: 'Icon',
                title: '图标',
                sortable: true
            }, {
                field: 'SortOrder',
                title: '排序',
                sortable: true
            }, {
                field: 'Description',
                title: '描述',
                sortable: true
            }, {
                field: 'Enabled',
                title: '是否激活',
                sortable: true
            }]

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
    return oTableInit;
};

var ButtonInit = function () {
    var oInit = new Object();
    var postdata = {};

    oInit.Init = function () {
        $("#btn_add").click(function () {
            $('#form').data('bootstrapValidator').resetForm(true);
            $("#chk_Enabled").prop("checked", true);
            $("#myModalLabel").text("新增");
            $("#myModal").find(".form-control").val("");
            $('#myModal').modal();
            postdata.ID = "-1";
        });

        $("#btn_edit").click(function () {
            $('#form').data('bootstrapValidator').resetForm(true);
            var arrselections = $("#tb_departments").bootstrapTable('getSelections');
            if (arrselections.length > 1) {
                toastr.warning('只能选择一行进行编辑');
                return;
            }
            if (arrselections.length <= 0) {
                toastr.warning('请选择有效数据');
                return;
            }
            $("#myModalLabel").text("编辑");
            $("#txt_Name").val(arrselections[0].Name);
            $("#txt_Code").val(arrselections[0].Code);
            $("#txt_Icon").val(arrselections[0].Icon);
            $("#txt_SortOrder").val(arrselections[0].SortOrder);
            $("#chk_Enabled").prop("checked", arrselections[0].Enabled);
            postdata.Id = arrselections[0].Id;
            $('#myModal').modal();
        });

        $("#btn_delete").click(function () {
            var arrselections = $("#tb_departments").bootstrapTable('getSelections');
            if (arrselections.length <= 0) {
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
                            url: "/Permission/Del",
                            data: { "data": JSON.stringify(arrselections) },
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
            postdata.Phone = $("#txt_Icon").val();
            postdata.SortOrder = $("#txt_SortOrder").val();
            postdata.Enabled = $('#chk_Enabled').prop('checked');
            $.ajax({
                type: "post",
                url: "/Permission/GetEdit",
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
        $("#btn_query").click(function () {
            $("#tb_departments").bootstrapTable('refresh');
        });
    };

    return oInit;
};