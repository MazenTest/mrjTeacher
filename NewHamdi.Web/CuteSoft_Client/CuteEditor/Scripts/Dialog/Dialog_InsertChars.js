var OxO55d1=["Verdana","innerHTML","Unicode","innerText","\x3Cspan style=\x27font-family:","\x27\x3E","\x3C/span\x3E","selfont","length","checked","value","charstable1","charstable2","fontFamily","style","display","block","none"];var editor=Window_GetDialogArguments(window);function getchar(obj){var Ox2d;var Ox2e=getFontValue()||OxO55d1[0];if(!obj[OxO55d1[1]]){return ;} ;Ox2d=obj[OxO55d1[1]];if(Ox2e==OxO55d1[2]){Ox2d=obj[OxO55d1[3]];} else {if(Ox2e!=OxO55d1[0]){Ox2d=OxO55d1[4]+Ox2e+OxO55d1[5]+obj[OxO55d1[1]]+OxO55d1[6];} ;} ;editor.PasteHTML(Ox2d);Window_CloseDialog(window);} ;function cancel(){Window_CloseDialog(window);} ;function getFontValue(){var Ox31=document.getElementsByName(OxO55d1[7]);for(var i=0;i<Ox31[OxO55d1[8]];i++){if(Ox31.item(i)[OxO55d1[9]]){return Ox31.item(i)[OxO55d1[10]];} ;} ;} ;function sel_font_change(){var Ox33=getFontValue()||OxO55d1[0];var Ox37b=Window_GetElement(window,OxO55d1[11],true);var Ox37c=Window_GetElement(window,OxO55d1[12],true);Ox37b[OxO55d1[14]][OxO55d1[13]]=Ox33;Ox37b[OxO55d1[14]][OxO55d1[15]]=(Ox33!=OxO55d1[2]?OxO55d1[16]:OxO55d1[17]);Ox37c[OxO55d1[14]][OxO55d1[15]]=(Ox33==OxO55d1[2]?OxO55d1[16]:OxO55d1[17]);} ;