var DataSourceTree = function(options) {
	this._data 	= options.data;
	this._delay = options.delay;
}

DataSourceTree.prototype.data = function(options, callback) {
	var self = this;
	var $data = null;

	if(!("name" in options) && !("type" in options)){
		$data = this._data;//the root tree
		callback({ data: $data });
		return;
	}
	else if("type" in options && options.type == "folder") {
		if("additionalParameters" in options && "children" in options.additionalParameters)
			$data = options.additionalParameters.children;
		else $data = {}//no data
	}

	if($data != null)//this setTimeout is only for mimicking some random delay
		setTimeout(function(){callback({ data: $data });} , parseInt(Math.random() * 500) + 200);

	//we have used static data here
	//but you can retrieve your data dynamically from a server using ajax call
	//checkout examples/treeview.html and examples/treeview.js for more info
};

var treedwcc;
function loadtree() {
	operationFunc("","getdwccTree",function(result){
		treedwcc = new DataSourceTree({data:  $.parseJSON(result)});
	});
}


var tree_data =
{
	'CCDM' : {name: 'CCDM', type: 'folder'}	,
	'DWDM' : {name: 'DWDM', type: 'folder'}	,
	'SJDWBM' : {name: 'SJDWBM', type: 'folder'}	,
	'TJSXH' : {name: 'TJSXH', type: 'folder'}	,
	'BZ' : {name: 'BZ', type: 'folder'}
}

var arr1 = ['CCDM','DWDM','SJDWBM','TJSXH','BZ'];

//for(var i = 0;i<arr1.length;i++)
//{
//	tree_data[arr1[i]]['additionalParameters'] ={
//		'children' : {
//			'1' : {name: '1', type: 'item'},
//			'2' : {name: '2', type: 'item'},
//			'3' : {name: '3', type: 'item'},
//			'4' : {name: '4', type: 'item'},
//			'5' : {name: '5', type: 'item'}
//		}
//	}
//}

tree_data['CCDM']['additionalParameters'] ={
	'children' :
	{
		'1' : {name: '1', type: 'item',id:'1'},
		'2' : {name: '2', type: 'item',id:'2'},
		'3' : {name: '3', type: 'item',id:'3'},
		'4' : {name: '4', type: 'item',id:'4'},
		'5' : {name: '5', type: 'item',id:'5'}
	}
}

var treeDataSourceybw = new DataSourceTree({data: tree_data});
var treeDataSourceybw111 ="";








var tree_data_2 = {
	'pictures' : {name: 'Pictures', type: 'folder', 'icon-class':'red'}	,
	'music' : {name: 'Music', type: 'folder', 'icon-class':'orange'}	,
	'video' : {name: 'Video', type: 'folder', 'icon-class':'blue'}	,
	'documents' : {name: 'Documents', type: 'folder', 'icon-class':'green'}	,
	'backup' : {name: 'Backup', type: 'folder'}	,
	'readme' : {name: '<i class="icon-file-text grey"></i> ReadMe.txt', type: 'item'},
	'manual' : {name: '<i class="icon-book blue"></i> Manual.html', type: 'item'}
}
tree_data_2['music']['additionalParameters'] = {
	'children' : [
		{name: '<i class="icon-music blue"></i> song1.ogg', type: 'item'},
		{name: '<i class="icon-music blue"></i> song2.ogg', type: 'item'},
		{name: '<i class="icon-music blue"></i> song3.ogg', type: 'item'},
		{name: '<i class="icon-music blue"></i> song4.ogg', type: 'item'},
		{name: '<i class="icon-music blue"></i> song5.ogg', type: 'item'}
	]
}
tree_data_2['video']['additionalParameters'] = {
	'children' : [
		{name: '<i class="icon-film blue"></i> movie1.avi', type: 'item'},
		{name: '<i class="icon-film blue"></i> movie2.avi', type: 'item'},
		{name: '<i class="icon-film blue"></i> movie3.avi', type: 'item'},
		{name: '<i class="icon-film blue"></i> movie4.avi', type: 'item'},
		{name: '<i class="icon-film blue"></i> movie5.avi', type: 'item'}
	]
}
tree_data_2['pictures']['additionalParameters'] = {
	'children' : {
		'wallpapers' : {name: 'Wallpapers', type: 'folder', 'icon-class':'pink'},
		'camera' : {name: 'Camera', type: 'folder', 'icon-class':'pink'}
	}
}
tree_data_2['pictures']['additionalParameters']['children']['wallpapers']['additionalParameters'] = {
	'children' : [
		{name: '<i class="icon-picture green"></i> wallpaper1.jpg', type: 'item'},
		{name: '<i class="icon-picture green"></i> wallpaper2.jpg', type: 'item'},
		{name: '<i class="icon-picture green"></i> wallpaper3.jpg', type: 'item'},
		{name: '<i class="icon-picture green"></i> wallpaper4.jpg', type: 'item'}
	]
}
tree_data_2['pictures']['additionalParameters']['children']['camera']['additionalParameters'] = {
	'children' : [
		{name: '<i class="icon-picture green"></i> photo1.jpg', type: 'item'},
		{name: '<i class="icon-picture green"></i> photo2.jpg', type: 'item'},
		{name: '<i class="icon-picture green"></i> photo3.jpg', type: 'item'},
		{name: '<i class="icon-picture green"></i> photo4.jpg', type: 'item'},
		{name: '<i class="icon-picture green"></i> photo5.jpg', type: 'item'},
		{name: '<i class="icon-picture green"></i> photo6.jpg', type: 'item'}
	]
}


tree_data_2['documents']['additionalParameters'] = {
	'children' : [
		{name: '<i class="icon-file-text red"></i> document1.pdf', type: 'item'},
		{name: '<i class="icon-file-text grey"></i> document2.doc', type: 'item'},
		{name: '<i class="icon-file-text grey"></i> document3.doc', type: 'item'},
		{name: '<i class="icon-file-text red"></i> document4.pdf', type: 'item'},
		{name: '<i class="icon-file-text grey"></i> document5.doc', type: 'item'}
	]
}

tree_data_2['backup']['additionalParameters'] = {
	'children' : [
		{name: '<i class="icon-archive brown"></i> backup1.zip', type: 'item'},
		{name: '<i class="icon-archive brown"></i> backup2.zip', type: 'item'},
		{name: '<i class="icon-archive brown"></i> backup3.zip', type: 'item'},
		{name: '<i class="icon-archive brown"></i> backup4.zip', type: 'item'}
	]
}
var treeDataSource2 = new DataSourceTree({data: tree_data_2});