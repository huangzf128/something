$(function(){

    $("#indiv").text("");
    $("#outdiv").text("");
    
    $("#btn").click(function(){
	var output = "";
	var colsep = "";
	if($("#rdocsvy").is(':checked')){
	    colsep = ',';
	}
	
	var colsInfo = parseColumnsInfo();

	var repeatColsIndex = [];
	$.each(colsInfo, function(index, value){
	    if(value.type == 3) {
		repeatColsIndex.push({index:index, order:value.order});
	    }
	});

	repeatColsIndex.sort(function(b, a){
            if( a.order < b.order ) return -1;
            if( a.order > b.order ) return 1;
            return 0;
	});

	$.each(colsInfo[repeatColsIndex[0].index].list, function(index, value){
	    colsInfo[repeatColsIndex[0].index].value = value;

	    if(repeatColsIndex.length == 1) {
		output = output + makeRow(colsInfo, colsep);
		
	    } else if(repeatColsIndex.length == 2) {
		
		$.each(colsInfo[repeatColsIndex[1].index].list, function(index, value){
		    colsInfo[repeatColsIndex[1].index].value = value;
		    output = output + makeRow(colsInfo, colsep);		    
		});
	    } else if(repeatColsIndex.length == 3) {
		$.each(colsInfo[repeatColsIndex[1].index].list, function(index, value){
		    colsInfo[repeatColsIndex[1].index].value = value;

		    $.each(colsInfo[repeatColsIndex[2].index].list, function(index, value){
			colsInfo[repeatColsIndex[2].index].value = value;
			output = output + makeRow(colsInfo, colsep);
		    });
		});

	    }

	});

	$("#outdiv").html(output);
	
    });

    $("#clear").click(function(){
	$("#outdiv").text("");
    });
})



var makeRow = function(colsInfo, colsep) {
    var line = "";
    var wrap = "";
    if($("#rdoquoy").is(':checked')){
	wrap = '"';
    }
    
    $.each(colsInfo, function(index, value){
	if(value.type == 1 || value.type == 3) {
	    line = line + wrap + value.value + wrap + colsep;
	} else if(value.type == 2) {

	    var num = getRandom(value.start, value.end);
	    line = line + wrap + pad(num, value.length) + wrap + colsep;	    
	    
	} else if(value.type == 4) {
	    line = line + wrap + value.list[colsInfo[value.index].value] + wrap + colsep;
	} else if(value.type == 5) {
	    line = line + wrap + colsInfo[value.index].value + wrap + colsep;
	}
    });

    if(colsep.length > 0){
	line = line.substring(0, line.length - 1);
    }    
    return line + "\r\n";
}


var parseColumnsInfo = function() {
    var input = $("#indiv").text();
    var inAry = input.split("\n");
    var colsInfo = [];
    $.each(inAry, function(index, value){
	var colInfo = value.split(",");
	if(colInfo[0] == 1) {
	    colsInfo.push({type:colInfo[0], value:colInfo[1]});
	} else if(colInfo[0] == 2) {
	    colsInfo.push({type:colInfo[0], start:colInfo[1], end:colInfo[2], length:getArrayEle(colInfo, 3)});
	} else if(colInfo[0] == 3) {
	    colsInfo.push({type:colInfo[0], order:colInfo[1], list:colInfo.splice(2, colInfo.length)});	    
	} else if(colInfo[0] == 4) {
	    var list = eval("({" + value.substr(4, value.length - 1) + "})");
	    colsInfo.push({type:colInfo[0], index:colInfo[1], list:list});
	} else if(colInfo[0] == 5) {
	    colsInfo.push({type:colInfo[0], index:colInfo[1]});
	} 
    });    
    
    return colsInfo;
}

var getRandom = function(s, e) {
    return (Math.floor(Math.random() * ((+e) - (+s))) + (+s));
}

function pad (str, max) {
    if(max == 0) return str;
    str = str.toString();
    return str.length < max ? pad("0" + str, max) : str;
}

var getArrayEle = function(ary, index) {
    if(ary.length < index + 1) {
	return 0;
    }
    return ary[index];
}
