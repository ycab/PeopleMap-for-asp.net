

function changePage(obj) {
   
    var test = document.getElementById("mainframe");
    var itemName = obj.getAttribute("data-iframe");
   
    
    if (itemName == "map") {
        test.src = '@Url.Content("~/Map/GetMap")';
    }
    else if (itemName == "user") {
        test.src = '@Url.Content("~/User/UserManage")';
    }
    else if (itemName == "user2") {
        test.src = '@Url.Content("~/User/UserManage2")';
    }
    else if (itemName == "rank") {
        test.src = '@Url.Content("~/Rank/GetRank")';
    } else if (itemName == "editPsw") {
        test.src = '@Url.Content("~/User/UserCodeEdit")';
    } else if (itemName == "editQZ") {
        test.src = '@Url.Content("~/Rank/RankEdit")';
    }
    else if (itemName == "robot") {
        test.src = '@Url.Content("~/Rank/GetRankByRobot")';
    } 
    
}
      