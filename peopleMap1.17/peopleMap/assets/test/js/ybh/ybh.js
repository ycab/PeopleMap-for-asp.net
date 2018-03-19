function show_review_state(cellvalue, options, rowObject) {
    if (cellvalue == null) return "";
    if (cellvalue == "yijidaishen") return "一级待审";
    if (cellvalue == "yijifahuixiugai") return "一级发回修改";
    if (cellvalue == "yijitongguo") return "一级通过";
    if (cellvalue == "erjidaishen") return "二级待审";
    if (cellvalue == "erjifahuixiugai") return "二级发回修改";
    if (cellvalue == "sanjidaishen") return "三级待审";
    if (cellvalue == "sanjifahuixiugai") return "三级发回修改";
    if (cellvalue == "daishencha") return "待审查";
    if (cellvalue == "daiyanshou") return "待验收";
    if (cellvalue == "notconfirm") return "待确认";
    if (cellvalue == "confirm") return "已确认";
    if (cellvalue == "shifandanyuan") return "示范单元";
    if (cellvalue == "dabiaodanyuan") return "达标单元";
    if (cellvalue == "budabiao") return "不达标";
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
    if (cellvalue == "shenqingyanqi") return rowObject.ACCEPTOR + "申请延期";
    if (cellvalue == "yiyanqi") return rowObject.ACCEPTOR + "已延期";
    if (cellvalue == "shenqingjiean") return rowObject.ACCEPTOR + "申请结案";
    if (cellvalue == "fahuichongban") return "发回重办";
    if (cellvalue == "yijiean") return "已结案";
}

function transfer_to_percent(cellvalue, options, rowObject) {
    return cellvalue.ToString("p2");
}