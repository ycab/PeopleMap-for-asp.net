function show_review_state(cellvalue, options, rowObject) {
    if (cellvalue == null) return "";

    if (cellvalue == "daishencha") return "待审查";
    if (cellvalue == "daiyanshou") return "待验收";
    if (cellvalue == "notconfirm") return "待确认";
    if (cellvalue == "confirm") return "已确认";
    if (cellvalue == "shifandanyuan") return "示范单元";
    if (cellvalue == "dabiaodanyuan") return "达标单元";
    if (cellvalue == "budabiao") return "不达标";
    if (cellvalue == "daizhuanfa") return "待转发";
    if (cellvalue == "shi") return "是";
    if (cellvalue == "wu") return "无";
    if (cellvalue == "sanjidaishen") return "三级待审";
    if (cellvalue == "sanjifahuixiugai") return "三级发回修改";
    if (cellvalue == "erjidaishen") return "二级待审";

    if (cellvalue == "erjifahuixiugai") return "二级发回修改";
    if (cellvalue == "yijidaishen") return "一级待审";
    if (cellvalue == "yijifahuixiugai") return "一级发回修改";
    if (cellvalue == "yijitongguo") return "一级通过";
}



function show_case_class(cellvalue, options, rowObject) {

    if (cellvalue == "huanjingweisheng") return "环境卫生";
    if (cellvalue == "yingjiansheshi") return "硬件设施";
    if (cellvalue == "lvhuayanghu") return "绿化养护";
    if (cellvalue == "rongmaozhixu") return "容貌秩序";
    if (cellvalue == "huanjingbaohu") return "环境保护";
    if (cellvalue == "qita") return "其他";
}




function show_the_case_process(serial_number, case_process_table) {
    $.ajax({
        url: "/Unit3/unit3_case_process_data?CASE_SERIAL_NUMBER=" + serial_number,
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

function anjianleixing(anjian)
{
    if (anjian == "huanjingweisheng") return "环境卫生";
    if (anjian == "yingjiansheshi") return "硬件设施";
    if (anjian == "lvhuayanghu") return "绿化养护";
    if (anjian == "rongmaozhixu") return "容貌秩序";
    if (anjian == "huanjingbaohu") return "环境保护";
    if (anjian == "qita") return "其他";   
}