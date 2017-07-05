
$(function () {
    //1.初始化Table
    var oTable = new TableInit();
    oTable.Init();
    $('#form').bootstrapValidator({
        message: 'This value is not valid',
        feedbackIcons: {
            valid: 'fa fa-check',
            invalid: 'fa fa-remove',
            validating: 'fa fa-refresh'
        },
        excluded: [':disabled'],
        //group: '.form-group',
        fields: {
            LoginName: {
                message: '工号无效!',
                validators: {
                    notEmpty: {
                        message: '工号不能为空!'
                    },
                    stringLength: {
                        min: 5,
                        max: 20,
                        message: '字符长度5-20!'
                    },
                    regexp: {
                        regexp: /^[A-Za-z0-9]+$/,
                        message: '只能由字母，数字组成!'
                    }
                }
            },
            FullName: {
                message: '姓名无效!',
                validators: {
                    notEmpty: {
                        message: '姓名不能为空!'
                    },
                    stringLength: {
                        min: 1,
                        max: 20,
                        message: '字符长度1-20!'
                    }
                }
            },
            Email: {
                validators: {
                    emailAddress: {
                        message: '不是有效的Email地址!'
                    }
                }
            },
            Phone: {
                validators: {
                    regexp: {
                        regexp: /^(0[0-9]{2,3}\-)?([2-9][0-9]{6,7})+(\-[0-9]{1,4})?$|(^(13[0-9]|15[0|3|6|7|8|9]|18[8|9])\d{8}$)/,
                        message: '请输入正确的电话号码，\n\n如：0591-6487256，15005059587.'
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
    //$("#form").data('formValidation').resetForm();
    $('#form').data('bootstrapValidator').resetForm(true);
});

var TableInit = function () {
    var oTableInit = new Object();
    //初始化Table
    oTableInit.Init = function () {
        $('#tb_departments').bootstrapTable({
            url: '/T_Auth_User/GetUser',         //请求后台的URL（*）
            method: 'post',                      //请求方式（*）
            //data: a,
            toolbar: '#toolbar',                //工具按钮用哪个容器
            striped: true,                      //是否显示行间隔色
            cache: false,                       //是否使用缓存，默认为true，所以一般情况下需要设置一下这个属性（*）
            pagination: true,                   //是否显示分页（*）
            sortable: true,                     //是否启用排序
            sortStable: true,
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
            sortName: "LoginName",
            columns: [{
                title: '全选',
                checkbox: true
            }, {
                field: 'LoginName',
                title: '工号',
                sortable: true
            },
            {
                field: 'FullName',
                title: '姓名',
                sortable: true
            }, {
                field: 'Phone',
                title: '电话',
                sortable: true
            }, {
                field: 'Email',
                title: 'Email',
                sortable: true
            }, {
                field: 'Enabled',
                title: '是否可用',
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
            $("#txt_LoginName").val(arrselections[0].LoginName);
            $("#txt_FullName").val(arrselections[0].FullName);
            $("#txt_Phone").val(arrselections[0].Phone);
            $("#txt_Email").val(arrselections[0].Email);
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
                title:"删除",
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
                    if (result)
                    {
                        $.ajax({
                            type: "post",
                            url: "/T_Auth_User/Del",
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
                            complete: function () {}
                        });
                    }
                }
            });

        });

        $("#btn_submit").click(function () {
            $('#form').data('bootstrapValidator').validate();
            var isVal = $("#form").data('bootstrapValidator').isValid();
            if (!isVal)
            {
                return;
            }
            postdata.LoginName = $("#txt_LoginName").val();
            postdata.FullName = $("#txt_FullName").val();
            postdata.Phone = $("#txt_Phone").val();
            postdata.Email = $("#txt_Email").val();
            postdata.Enabled = $('#chk_Enabled').prop('checked');
            $.ajax({
                type: "post",
                url: "/T_Auth_User/GetEdit",
                data: { "data": JSON.stringify(postdata) },
                success: function (data, status) {
                    if (status == "success") {
                        $('#myModal').modal('hide');
                        toastr.success('提交数据成功');
                        $("#tb_departments").bootstrapTable('refresh');
                    }
                },
                error: function () {
                    toastr.error('提交失败');
                },
                complete: function () {

                }
            });
        });
        //权限
        $('#btn_Auther').click(function () {

            var arrselections = $("#tb_departments").bootstrapTable('getSelections');
            if (arrselections.length > 1) {
                toastr.warning('只能选择一行进行编辑');
                return;
            }
            if (arrselections.length <= 0) {
                toastr.warning('请选择有效数据');
                return;
            }
            $("#checkbox_content span").remove();
            $.post("/T_Auth_User/Set_Auther", { 'UserId': arrselections[0].Id }, function (result) {
                if (result.Msg == "success") {
                    $.each(result.data, function (i, n) {
                        var str;
                        if (!n.IsChecked)
                            $("#checkbox_content").append("<span style='display:inline-block;width:120px;'><label style='display: block; padding-left: 15px; text-indent: -15px;'><input type='checkbox' id='" + n.id + "'> " + n.Name);
                        else
                            $("#checkbox_content").append("<span style='display:inline-block;width:120px;'><label style='display: block; padding-left: 15px; text-indent: -15px;'><input type='checkbox' checked='checked' id='" + n.id + "'> " + n.Name);
                    });
                    $('#myModal2').modal();
                }
            });
        });

        $('#btn_SetAuther_submit').click(function () {

            var data = [];
            var arrselections = $("#tb_departments").bootstrapTable('getSelections');
            $("#checkbox_content input:checkbox").each(function (i, n) {
                if ($(n).prop('checked') == true) {
                    data.push($(n).attr("id"));
                }
            });

            $.ajax({
                type: "post",
                url: "/T_Auth_User/Save_Auther",
                data: { "data": JSON.stringify(data), "UserId": arrselections[0].Id },
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
        //重置密码
        $("#btn_resetkey").click(function () {
            var arrselections = $("#tb_departments").bootstrapTable('getSelections');
            if (arrselections.length <= 0) {
                toastr.warning('请选择有效数据');
                return;
            }
            bootbox.confirm({
                title: "重置密码",
                message: "确认要重置密码吗？",
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
                            url: "/T_Auth_User/ResetKey",
                            data: { "data": JSON.stringify(arrselections) },
                            success: function (data, status) {
                                if (status == "success") {
                                    $('#myModal').modal('hide');
                                    toastr.success('重置密码成功.');
                                    $("#tb_departments").bootstrapTable('refresh');
                                } else {
                                    $('#myModal').modal('hide');
                                    toastr.success('重置密码失败(1).');
                                }
                            },
                            error: function () { toastr.error('重置密码失败(2).'); },
                            complete: function () { }
                        });
                    }
                }
            });
        });

        $("#btn_SetPro").click(function () {

            var arrselections = $("#tb_departments").bootstrapTable('getSelections');
            if (arrselections.length > 1) {
                toastr.warning('只能选择一行进行编辑');
                return;
            }
            if (arrselections.length <= 0) {
                toastr.warning('请选择有效数据');
                return;
            }
            //.val(['0','2']).trigger('change')
            $('#myModal3').modal();

            $.get('/CNYD_STRUCT_TREE/GetProInfo', function (result) {

                $.get('/T_Auth_User/GetUserPro', { "UserID": arrselections[0].Id }, function (rel) {
                    $("#Choise_PJ").select2({
                        data: result.data,
                        language: "zh-CN",
                        placeholder: "请选择工程...",
                        maximumSelectionLength: 20,
                        multiple: true
                    }).val(null).trigger("change");
                    $("#Choise_PJ").val(rel.data).trigger('change');
                });
            });
        });

        $("#btn_SetPro_submit").click(function () {
            var arrselections = $("#tb_departments").bootstrapTable('getSelections');
            $.post('/T_Auth_User/Save_UserPro', {"data":JSON.stringify($("#Choise_PJ").val()),"UserId": arrselections[0].Id},
                function (rel) {
                    if (rel.Msg == "success") {
                        $('#myModal3').modal('hide');
                        toastr.success('提交数据成功');
                    }
                }
            );
        });
        $("#btn_query").click(function () {
            $("#tb_departments").bootstrapTable('refresh');
        });
    };

    return oInit;
};