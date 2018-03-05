function pageWidth() {
    return window.innerWidth != null ? window.innerWidth : document.documentElement && document.documentElement.clientWidth ? document.documentElement.clientWidth : document.body != null ? document.body.clientWidth : null;
}
function pageHeight() {
    return window.innerHeight != null ? window.innerHeight : document.documentElement && document.documentElement.clientHeight ? document.documentElement.clientHeight : document.body != null ? document.body.clientHeight : null;
}
function posLeft() {
    return typeof window.pageXOffset != 'undefined' ? window.pageXOffset : document.documentElement && document.documentElement.scrollLeft ? document.documentElement.scrollLeft : document.body.scrollLeft ? document.body.scrollLeft : 0;
}
function posTop() {
    return typeof window.pageYOffset != 'undefined' ? window.pageYOffset : document.documentElement && document.documentElement.scrollTop ? document.documentElement.scrollTop : document.body.scrollTop ? document.body.scrollTop : 0;
}
function getEl(x) {
    return document.getElementById(x);
}



var timer = null;
function goingDown(elm,toTop){
 var top  = parseInt(elm.offsetTop);
 var change = toTop-top;
   if(change<=0) {
   clearTimeout(timer);
  return;
 }
 var total=top+Math.ceil((change/12));
 elm.style.top=total+'px';
 function c() {
       goingDown(elm,toTop);
 }
 timer=setTimeout(c,10);
}



function goingUp(elm,toTop){
 var top  = parseInt(elm.offsetTop);
 var change = top-toTop;
  if(change<=0) {
   clearTimeout(timer);
  return;
 }
 var total=top-Math.ceil((change/12));
 elm.style.top=total+'px';
 function c() {
       goingUp(elm,toTop);
 }
 timer=setTimeout(c,10);
}


function scrollFix() {
	jobTrend();
	var obbx = getEl('mbox');
	if(obbx.style.display != 'none'){	
	clearTimeout(timer);
    var tp = posTop() + ((pageHeight() - hit) / 2) - 12;
    var lt = posLeft() + ((pageWidth() - wid) / 2) - 12;
	tp = (tp < 0 ? 0 : tp);
	if(obbx.offsetTop < tp){
		goingDown(obbx,tp);
	}
	else{
		goingUp(obbx,tp);		
	}
    obbx.style.left = (lt < 0 ? 0 : lt) + 'px';
	}
}
function sizeFix() {
    var obol = getEl('ol');
    obol.style.height = pageHeight() + 'px';
    obol.style.width = pageWidth() + 'px';
}
function kp(e) {
    ky = e ? e.which : event.keyCode;
    if (ky == 88 || ky == 120) hideabtModal();
    return false
}
function inf(h) {
    tag = document.getElementsByTagName('select');
    for (i = tag.length - 1; i >= 0; i--) tag[i].style.visibility = h;
//    tag = document.getElementsByTagName('iframe');
//    for (i = tag.length - 1; i >= 0; i--) tag[i].style.visibility = h;
    tag = document.getElementsByTagName('object');
    for (i = tag.length - 1; i >= 0; i--) tag[i].style.visibility = h;
}

var wid = 0;
var hit = 0;

function showabtModal(obl, wd, ht) {
	wid=wd;
	hit=ht;
    var h = 'hidden';
    var b = 'block';
    var p = 'px';
	
	if(!getEl('ol') || !getEl('mbd')){
		initmb();
	}
	
    var obol = getEl('ol');
    var obbxd = getEl('mbd');
    obbxd.innerHTML = getEl(obl).innerHTML;
    obol.style.height = document.body.offsetHeight + p;
    obol.style.width = document.body.offsetWidth + p;
    //obol.style.top = posTop() + p;
    //obol.style.left = posLeft() + p;
    obol.style.display = b;
    var tp = posTop() + ((pageHeight() - ht) / 2) - 12;
    var lt = posLeft() + ((pageWidth() - wd) / 2) - 12;
    var obbx = getEl('mbox');
    obbx.style.top = (tp < 0 ? 0 : tp) + p;
    obbx.style.left = (lt < 0 ? 0 : lt) + p;
    obbx.style.width = wd + p;
    obbx.style.height = ht + p;
    inf(h);
    obbx.style.display = b;
    return false;
}
function hideabtModal() {
    var v = 'visible';
    var n = 'none';
    getEl('ol').style.display = n;
    getEl('mbox').style.display = n;
    inf(v);
    document.onkeypress = ''
}
function initmb() {
    var ab = 'absolute';
    var n = 'none';
    var obody = document.getElementsByTagName('body')[0];
    var frag = document.createDocumentFragment();
    var obol = document.createElement('div');
    obol.setAttribute('id', 'ol');
    obol.style.display = n;
    obol.style.position = ab;
    obol.style.top = 0;
    obol.style.left = 0;
    obol.style.zIndex = 998;
    obol.style.width = '100%';
    frag.appendChild(obol);
    var obbx = document.createElement('div');
    obbx.setAttribute('id', 'mbox');
    obbx.style.display = n;
    obbx.style.position = ab;
    obbx.style.zIndex = 999;
    var obl = document.createElement('span');
    obbx.appendChild(obl);
    var obbxd = document.createElement('div');
    obbxd.setAttribute('id', 'mbd');
    obl.appendChild(obbxd);
    frag.insertBefore(obbx, obol.nextSibling);
    obody.insertBefore(frag, obody.firstChild);
	
    window.onscroll = scrollFix;
    window.onresize = sizeFix;
}
window.onload = initmb;


var indeedFlag = 0;
//window.onscroll=scroll;
function jobTrend()
{


	if(document.getElementById("indeedImg") && document.getElementById("indeed")){

	if(indeedFlag == 1){
		return false;
	
	}
	
	
	indeed=document.getElementById("indeed").value;
	indeedImg=document.getElementById("indeedImg");
	indeedImg.src="http://www.indeed.com/trendgraph/jobgraph.png?q="+indeed+"&relative=1";
	
	indeedFlag=1;
	//alert(indeedFlag);
	}

}