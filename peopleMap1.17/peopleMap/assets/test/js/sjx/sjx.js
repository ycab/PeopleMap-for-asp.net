function DisplayAndHiddenBtn(btnId, type) {
    var currentBtn = document.getElementById(btnId);
    if (type == "d") {
        currentBtn.style.display = "block"; //style中的display属性
    }
    else if (type == "h") {
        currentBtn.style.display = "none";
    }
}
function btn_show_hide(btnId, type) {
    var currentBtn = document.getElementById(btnId);
    if (type == "d") {
        currentBtn.style.visibility = "visible"; //style中的display属性
    }
    else if (type == "h") {
        currentBtn.style.visibility = "hidden";
    }
}
function TransferString(content) {
    var string = content;
    try {
        string = string.replace(/\r\n/g, "<br/>")
        string = string.replace(/\n/g, "<br/>");
    } catch (e) {
        alert(e.message);
    }
    return string;
}
function line2br(text) {
    $("<div>").text(text).html().split("\n").join("<br />");
}
function my(content) {
    return content.replace("/n", "");
}
function show_remark_and_score(user_serial_number, UNIT_PROFILE_REMARK, QUOTA_MANAGEMENT_REMARK, ADVANCE_PROFILE_REMARK, state, profile_total_score, quota_total_score, advance_total_score) {
    $.ajax({
        url: "/Unit1/unit1_remark_score_data?USER_SERIAL_NUMBER=" + user_serial_number,
        type: "post",
        dataType: "json",
        success: function (response) {
            // $("#UNIT_PROFILE_REMARK").html(response[0].UNIT_PROFILE_REMARK);
             var ss = response[0].QUOTA_MANAGEMENT_REMARK;

            //alert(my(ss));
            $("#QUOTA_MANAGEMENT_REMARK").html ( response[0].QUOTA_MANAGEMENT_REMARK);
          //  $("#QUOTA_MANAGEMENT_REMARK").innerText=response[0].QUOTA_MANAGEMENT_REMARK;
            $("#ADVANCE_PROFILE_REMARK").html(response[0].ADVANCE_PROFILE_REMARK);
            // $("#UNIT_PROFILE_REMARK").attr("readOnly", "true");
            $("#QUOTA_MANAGEMENT_REMARK").attr("readOnly", "true");
            $("#ADVANCE_PROFILE_REMARK").attr("readOnly", "true");
            if (state == 2) {
                var incontent = "";
                incontent += '<label style="width:50%" class="control-label no-padding-right"> ' + "当前资料得分: " + response[0].DATA_TOTAL_SCORE + '</label>';
                //document.getElementById(profile_total_score).innerHTML = incontent;
                document.getElementById(quota_total_score).innerHTML = incontent;
                document.getElementById(advance_total_score).innerHTML = incontent;
            }
            return null;
        }
    })
}
function show_review_state(cellvalue, options, rowObject) {
    if (cellvalue == null) return "";
    if (cellvalue == "yijidaishen") return "一级待审";
    if (cellvalue == "yijifahuixiugai") return "一级发回修改";
    if (cellvalue == "yijitongguo") return "一级通过";
    if (cellvalue == "daishencha") return "待审查";
    if (cellvalue == "daiyanshou") return "待验收";
    if (cellvalue == "notconfirm") return "待确认";
    if (cellvalue == "confirm") return "已确认";
    if (cellvalue == "shifandanyuan") return "示范单元";
    if (cellvalue == "dabiaodanyuan") return "达标单元";
    if (cellvalue == "yichuli") return "已处理";
    if (cellvalue == "yigenggai") return "已更改";
    if (cellvalue == "weigenggai") return "未更改";
    if (cellvalue == "budabiao") return "不达标";
    if (cellvalue == "zhuanjiaodaiyan") return "";
    if (cellvalue == "shi") return "是";
    if (cellvalue == "fou") return "否";
    if (cellvalue == "daizhuanfa") return "";
    if (cellvalue == "dabiaozhaipai") return "达标单元摘牌";
    if (cellvalue == "shifanzhaipai") return "示范单元摘牌";
    if (cellvalue == "shifanjianggebudabiao") return "示范降格不达标";



}
function show_case_state(cellvalue, options, rowObject) {

    if (cellvalue == null) return "";
    if (cellvalue == "daiqianfa") return "待签发";
    if (cellvalue == "yiqianfa") return "已签发";
    if (cellvalue == "erjiqianfa") return rowObject.DISTRICT + "已签发";
    if (cellvalue == "erjiqianshou") return rowObject.DISTRICT + "已签收";
    if (cellvalue == "sanjiqianfa") return rowObject.STREET + "已签发";
    if (cellvalue == "sanjiqianshou") return rowObject.STREET + "已签收";
    if (cellvalue == "sijiqianshou") return rowObject.ACCEPTOR + "已签收";
   // if (cellvalue == "shenqingyanqi") return rowObject.ACCEPTOR + "申请延期";
    if (cellvalue == "yiyanqi") return rowObject.ACCEPTOR + "已延期";
    if (cellvalue == "shenqingjiean") return "待结案";
    if (cellvalue == "fahuichongban") return "发回重办";
    if (cellvalue == "yijiean") return "已结案";
    if (cellvalue == "tongguo") return "通过";
    if (cellvalue == "butongguo") return "不通过";
    if (cellvalue == "shenqingyanqi") return "待处理";

}
function case_class(cellvalue, options, rowObject) {
    if (cellvalue == null) return "";
    if (cellvalue == "huanjingweisheng") return "环境卫生";
    if (cellvalue == "yingjiansheshi") return "硬件设施";
    if (cellvalue == "lvhuayanghu") return "绿化养护";
    if (cellvalue == "rongmaozhixu") return "容貌秩序";
    if (cellvalue == "huanjingbaohu") return "环境保护";
    if (cellvalue == "qita") return "其他";
    if (cellvalue == "yiban") return "一般";
    if (cellvalue == "yanzhong") return "严重";
}
function case_severe_class_show(cellvalue) {
    if (cellvalue == null) return "";
    if (cellvalue == "huanjingweisheng") return "环境卫生";
    if (cellvalue == "yingjiansheshi") return "硬件设施";
    if (cellvalue == "lvhuayanghu") return "绿化养护";
    if (cellvalue == "rongmaozhixu") return "容貌秩序";
    if (cellvalue == "huanjingbaohu") return "环境保护";
    if (cellvalue == "qita") return "其他";
    if (cellvalue == "yiban") return "一般";
    if (cellvalue == "yanzhong") return "严重";
}
function show_acceptance_material_live_detail(user_serial_number, UNIT_PROFILE_REMARK, QUOTA_MANAGEMENT_REMARK, ADVANCE_PROFILE_REMARK, DATA_TOTAL_SCORE, PROBLEM_DESCRIPTION, LIVE_SCORE, state) {
    $.ajax({
        url: "/Unit1/unit1_acceptance_detail_material_data?USER_SERIAL_NUMBER=" + user_serial_number,
        type: "post",
        dataType: "json",
        success: function (response) {
            var text1, text2, text3;

            text2 = response[0].QUOTA_MANAGEMENT_REMARK == null ? " " : response[0].QUOTA_MANAGEMENT_REMARK;
            text3 = response[0].ADVANCE_PROFILE_REMARK == null ? " " : response[0].ADVANCE_PROFILE_REMARK;
            var score_profile;


            $("#QUOTA_MANAGEMENT_REMARK").html("得分：" + response[0].QUOTA_MANAGEMENT_SCORE + "\n评语:\n" + text2);
            $("#ADVANCE_PROFILE_REMARK").html("得分：" + response[0].ADVANCE_PROFILE_SCORE + "\n评语:\n" + text3);
            $("#DATA_TOTAL_SCORE").val(response[0].DATA_TOTAL_SCORE);
            var can_show = response[0].SEAT_CONFIRM;
            var text4, text5;
            if (can_show == "confirm") {
                text1 = response[0].UNIT_PROFILE_REMARK == null ? " " : response[0].UNIT_PROFILE_REMARK;
                score_profile = response[0].UNIT_PROFILE_SCORE;
                text4 = response[0].PROBLEM_DESCRIPTION == null ? " " : response[0].PROBLEM_DESCRIPTION;
                text5 = response[0].LIVE_SCORE == null ? "" : response[0].LIVE_SCORE;
            }
            else {
                text4 = "";
                text5 = "";
                text1 = "";
                score_profile = "";
                var data_total_score = parseFloat(response[0].QUOTA_MANAGEMENT_SCORE + response[0].QUOTA_MANAGEMENT_SCORE);
                $("#DATA_TOTAL_SCORE").val(data_total_score);
            }
            $("#UNIT_PROFILE_REMARK").html("得分：" + score_profile + "\n评语:\n" + text1);
            $("#PROBLEM_DESCRIPTION").val("问题描述:\n" + text4);
            $("#LIVE_SCORE").val(text5);
            return null;
        }
    })
}
//============================================专家组手机查看时，调用此函数===========================================//
function expert_review_detail(user_serial_number, PROBLEM_DESCRIPTION, LIVE_SCORE, state) {
    $.ajax({
        url: "/Unit1/unit1_acceptance_detail_material_data?USER_SERIAL_NUMBER=" + user_serial_number,
        type: "post",
        dataType: "json",
        success: function (response) {
            var text1 = response[0].UNIT_PROFILE_REMARK == null ? " " : response[0].UNIT_PROFILE_REMARK;
            var text2 = response[0].UNIT_PROFILE_SCORE == null ? " " : response[0].UNIT_PROFILE_SCORE;
            var text4 = response[0].PROBLEM_DESCRIPTION == null ? " " : response[0].PROBLEM_DESCRIPTION;
            var text5 = response[0].LIVE_SCORE == null ? "" : response[0].LIVE_SCORE;
            var text6 = response[0].CASE_BIG_CLASS == null ? "" : response[0].CASE_BIG_CLASS;
            var text7 = response[0].SEVERE_LEVEL == null ? "" : response[0].SEVERE_LEVEL;

            $("#PROBLEM_DESCRIPTION").val(text4);
            $("#LIVE_SCORE").val(text5);
            $("#UNIT_PROFILE_REMARK").val(text1);
            //alert(text2);
            $("#UNIT_PROFILE_SCORE").val(text2);
            $("#CASE_BIG_CLASS").val(text6);
            $("#SEVERE_LEVEL").val(text7);
            //===================================显示图片==========================================//视图加入字段后路径从视图中读
            if (state == "app") {
                var PICTURE_PATH = response[0].PICTURE1;
                //var PICTURE_PATH = "http://localhost:38113/Uploads/CASE_PICTURE_POST/9ed648cb-b12c-4769-b913-4535a274b978.jpg,http://localhost:38113/Uploads/CASE_PICTURE_POST/fcf3049f-c379-482d-af76-8c09ab119fca.jpg,http://localhost:38113/Uploads/CASE_PICTURE_POST/61e8ff0c-b696-469b-a1c4-41aafe2688e0.jpg";

                if (PICTURE_PATH != null) {
                    var pic_path = PICTURE_PATH.split(",");
                    // <li><a href="#" target="_blank"><img src="~/assets/test/js/sjx/pic/1.jpg" width="220" height="105" /></a></li>
                    var pic_content = "";
                    for (var i = 0; i < pic_path.length; i++) {
                        pic_content += '<a href="' + pic_path[i] + '"target="cont"><img src="' + pic_path[i] + '" width="180" height="105" /></a>';
                    }
                    //alert(pic_content);
                    document.getElementById("look_the_picture").innerHTML = pic_content;
                }
            }
            return null;
        }
    })
}

function look_the_problem_description(user_serial_number, PROBLEM_DESCRIPTION_LOOK, state) {
    $.ajax({
        url: "/Unit1/unit1_acceptance_detail_material_data?USER_SERIAL_NUMBER=" + user_serial_number,
        type: "post",
        dataType: "json",
        success: function (response) {

            var text = response[0].PROBLEM_DESCRIPTION == null ? " " : response[0].PROBLEM_DESCRIPTION;

            $("#PROBLEM_DESCRIPTION_LOOK").val(text);
            return null;
        }
    })
}
function select_content(url, ssss) {
    $.ajax({
        url: url,
        type: "post",
        dataType: "json",
        success: function (response) {
            var select_content = "";
            for (var i = 0; i < response.UNIT_CLASS.length; i++) {
                select_content += '<option value="' + response.UNIT_CLASS[i] + '">' + response.UNIT_CLASS[i];
                select_content += '</option>';
            }
            select_content = '<option value=""></option>' + select_content;
            document.getElementById(ssss).innerHTML = select_content;
        }
    })
}
function dddd() {

}

function look_the_apply_reason(serial_number, APPLY_REASON, state) {
    $.ajax({
        url: "/Unit1/unit1_modify_reason_data?USER_SERIAL_NUMBER=" + serial_number,
        type: "post",
        dataType: "json",
        success: function (response) {

            var text = response[0].APPLY_REASON == null ? " " : response[0].APPLY_REASON;

            $("#APPLY_REASON").val(text);
            return null;
        }
    })
}
function look_the_appeal_reason(serial_number, APPLY_REASON, state) {
    $.ajax({
        url: "/Unit1/unit1_appeal_reason_data?USER_SERIAL_NUMBER=" + serial_number,
        type: "post",
        dataType: "json",
        success: function (response) {

            var text = response[0].APPLY_REASON == null ? " " : response[0].APPLY_REASON;

            $("#appeal_reason").val(text);
            return null;
        }
    })
}

function look_or_change_the_data(serial_number, APPLY_REASON, state) {
    $.ajax({
        url: "/Unit1/unit1_modify_reason_data?USER_SERIAL_NUMBER=" + serial_number,
        type: "post",
        dataType: "json",
        success: function (response) {

            var text = response[0].APPLY_REASON == null ? " " : response[0].APPLY_REASON;

            $("#appeal_reason").val(text);
            return null;
        }
    })
}
function show_the_case_process(serial_number, case_process_table) {
    $.ajax({
        url: "/Unit1/unit1_case_process_data?CASE_SERIAL_NUMBER=" + serial_number,
        type: "post",
        dataType: "json",
        success: function (response) {

            // var text = response[0].APPLY_REASON == null ? " " : response[0].APPLY_REASON;
            var table_content = "<thead><tr><th width=\"20%\">操作时间</th><th width=\"20%\">操作状态</th><th width=\"20%\">图片</th><th width=\"40%\">备注说明</th></tr></thead><tbody>";
            for (var i = 0; i < response.length; i++) {
                table_content += '<tr><th>' + ChangeDateFormat(response[i].DEAL_TIME) + '</th><th>' + response[i].DEAL_PERSON + '</th><th>' + show_case_process_state(response[i].PICTURE1) + '</th><th>' + show_case_process_state(response[i].REMARKS) + '</th></tr>';
                //select_content += '<option value="' + response.UNIT_CLASS[i] + '">' + response.UNIT_CLASS[i];
                //select_content += '</option>';
            }
            table_content += "</tbody>";
            document.getElementById(case_process_table).innerHTML = table_content;
        }
    })
}
function show_case_process_state(x) {
    if (x == null) return "";
    else return x;
}
function ChangeDateFormat(jsondate) {
    jsondate = jsondate.replace("/Date(", "").replace(")/", "");
    if (jsondate.indexOf("+") > 0) {
        jsondate = jsondate.substring(0, jsondate.indexOf("+"));
    } else if (jsondate.indexOf("-") > 0) {
        jsondate = jsondate.substring(0, jsondate.indexOf("-"));
    }
    var date = new Date(parseInt(jsondate, 10));
    var month = date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;
    var currentDate = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
    var hour = date.getHours() < 10 ? "0" + date.getHours() : date.getHours();
    var minute = date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes();
    var second = date.getSeconds() < 10 ? "0" + date.getSeconds() : date.getSeconds();
    return date.getFullYear() + "-" + month + "-" + currentDate + " " + hour + ":" + minute + ":" + second;
}
function show_post_picture(PICTURE_PATH, pic_area_1) {
    if (PICTURE_PATH != null) {
        var pic_path = PICTURE_PATH.split(",");
        // <li><a href="#" target="_blank"><img src="~/assets/test/js/sjx/pic/1.jpg" width="220" height="105" /></a></li>
        var pic_content = "";
        for (var i = 0; i < pic_path.length; i++) {
            pic_content += '<a href="' + pic_path[i] + '"target="cont"><img src="' + pic_path[i] + '" width="180" height="105" /></a>';
        }
        //alert(pic_content);
        document.getElementById("pic_area_1").innerHTML = pic_content;
    }
}
function show_reply_picture(PICTURE_PATH, pic_area_2) {
    if (PICTURE_PATH != null) {
        var pic_path = PICTURE_PATH.split(",");
        // <li><a href="#" target="_blank"><img src="~/assets/test/js/sjx/pic/1.jpg" width="220" height="105" /></a></li>
        var pic_content = "";
        for (var i = 0; i < pic_path.length; i++) {
            pic_content += '<a href="' + pic_path[i] + '"target="cont"><img src="' + pic_path[i] + '" width="180" height="105" /></a>';
        }
        //alert(pic_content);
        document.getElementById("pic_area_2").innerHTML = pic_content;
    }
}

