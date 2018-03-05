<!--

/*
Configure menu styles below
NOTE: To edit the link colors, go to the STYLE tags and edit the ssm2Items colors
*/
YOffset=150; // no quotes!!
XOffset=0;
staticYOffset=30; // no quotes!!
slideSpeed=20 // no quotes!!
waitTime=100; // no quotes!! this sets the time the menu stays out for after the mouse goes off it.
menuBGColor="transparent";
menuIsStatic="yes"; //this sets whether menu should stay static on the screen
menuWidth=170; // Must be a multiple of 10! no quotes!!
menuCols=2;
hdrFontFamily="verdana";
hdrFontSize="2";
hdrFontColor="white";
hdrBGColor="#30321A";
hdrAlign="left";
hdrVAlign="center";
hdrHeight="15";
linkFontFamily="Verdana";
linkFontSize="2";
linkBGColor="white";
linkOverBGColor="#CCCC7A";
linkTarget="_top";
linkAlign="Left";
barBGColor="#444444";
barFontFamily="Verdana";
barFontSize="2";
barFontColor="white";
barVAlign="center";
barWidth=30; // no quotes!!
barText="QUICK MENU"; // <IMG> tag supported. Put exact html for an image to show.

///////////////////////////
//ssmItems[4]=["Features", "../school-new1-layout2/features.htm", "_new"]
// ssmItems[...]=[name, link, target, colspan, endrow?] - leave 'link' and 'target' blank to make a header
ssmItems[0]=["Menu"] //create header
ssmItems[1]=["Home", "default.aspx", ""]
ssmItems[2]=["About Us", "aboutus.aspx",""]
ssmItems[3]=["Modules", "modules.aspx", ""]
ssmItems[4]=["Features", "features.aspx", ""]
ssmItems[5]=["Contact Us", "contactus.aspx", ""]
ssmItems[6]=["Free Registration", "register.aspx", ""]
ssmItems[7]=["Product Tour", "aboutus.aspx", ""]
ssmItems[8]=["Request for Demo", "aboutus.aspx", ""]
ssmItems[9]=["Request for Quote", "contactus.aspx", ""]
ssmItems[10]=["Cost Benefit Analysis", "costbenefitanalysis.aspx", ""]
ssmItems[11]=["FAQ", "faq.aspx", ""]
ssmItems[12]=["Sitemap", "aboutus.aspx", ""]
ssmItems[13]=["External Links", "", ""]
ssmItems[14]=["Aboutus", "aboutus.aspx", ""]


buildMenu();

//-->