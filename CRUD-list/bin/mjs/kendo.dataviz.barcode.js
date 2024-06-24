/**
 * Kendo UI v2024.2.514 (http://www.telerik.com/kendo-ui)
 * Copyright 2024 Progress Software Corporation and/or one of its subsidiaries or affiliates. All rights reserved.
 *
 * Kendo UI commercial licenses may be obtained at
 * http://www.telerik.com/purchase/license-agreement/kendo-ui-complete
 * If you do not own a commercial license, this file shall be governed by the trial license terms.
 */
import"./kendo.dataviz.core.js";import"./kendo.drawing.js";var __meta__={id:"dataviz.barcode",name:"Barcode",category:"dataviz",description:"Barcode widget",depends:["dataviz.core"]};!function(t,e){var a=window.kendo,n=a.ui.Widget,r=t.extend,i=a.deepExtend,s=t.inArray,o=t.isPlainObject,h=a.drawing,d=a.geometry,u=a.drawing.util.defined,c=a.dataviz,l=c.Box2D,p=c.TextBox,v=/^\d+$/,f=/^[a-z0-9]+$/i;function g(t,e,a){return t.substring(e,e+a)}var b=a.Class.extend({init:function(t){this.setOptions(t)},setOptions:function(t){var e=this;e.options=r({},e.options,t),e.quietZoneLength=e.options.addQuietZone?2*e.options.quietZoneLength:0},encode:function(t,e,a){var n=this;return u(t)&&(t+=""),n.initValue(t,e,a),n.options.addQuietZone&&n.addQuietZone(),n.addData(),n.options.addQuietZone&&n.addQuietZone(),{baseUnit:n.baseUnit,pattern:n.pattern}},options:{quietZoneLength:10,addQuietZone:!0,addCheckSum:!0},initValue:function(){},addQuietZone:function(){this.pattern.push(this.options.quietZoneLength||10)},addData:function(){},invalidCharacterError:function(t){throw new Error(a.format("Character '{0}' is not valid for symbology {1}",t,this.name))}}),w={},m=b.extend({minBaseUnitLength:.7,addData:function(){var t=this,e=t.value;t.addStart();for(var a=0;a<e.length;a++)t.addCharacter(e.charAt(a));t.options.addCheckSum&&t.pushCheckSum(),t.addStop(),t.prepareValues()},addCharacter:function(t){var e=this,a=e.characterMap[t];a||e.invalidCharacterError(t),e.addBase(a)},addBase:function(){}}),S={addCharacter:function(t){var e=this;e.characterMap[t]?e.addBase(e.characterMap[t]):t.charCodeAt(0)>127?e.invalidCharacterError(t):e.addExtended(t.charCodeAt(0))},addExtended:function(t){for(var e,a=this,n=0;n<a.extendedMappings.length;n++)if(e=a.extendedMappings[n].call(a,t)){for(var r=0;r<e.length;r++)a.addBase(e[r]);return void(a.dataLength+=e.length-1)}},extendedMappings:[function(t){if(97<=t&&t<=122){var e=this;return[e.characterMap[e.shiftCharacters[0]],e.characterMap[String.fromCharCode(t-32)]]}},function(t){if(33<=t&&t<=58){var e=this;return[e.characterMap[e.shiftCharacters[1]],e.characterMap[String.fromCharCode(t+32)]]}},function(t){if(1<=t&&t<=26){var e=this;return[e.characterMap[e.shiftCharacters[2]],e.characterMap[String.fromCharCode(t+64)]]}},function(t){var e,a,n=this;if(n.specialAsciiCodes[t]){e=[];for(var r=0;r<n.specialAsciiCodes[t].length;r++)e.push(n.characterMap[n.shiftCharacters[3]]),e.push(n.characterMap[n.specialAsciiCodes[t][r]])}else a=6*Math.floor(t/32)+(t-27)%32+64,e=[n.characterMap[n.shiftCharacters[3]],n.characterMap[String.fromCharCode(a)]];return e}],specialAsciiCodes:{0:["U"],64:["V"],96:["W"],127:["T","X","Y","Z"]},shiftValuesAsciiCodes:{39:36,40:47,41:43,42:37},characterMap:{"+":!1,"/":!1,$:!1,"%":!1},shiftCharacters:["SHIFT0","SHIFT1","SHIFT2","SHIFT3"]};w.code39=m.extend({name:"Code 39",checkSumMod:43,minRatio:2.5,maxRatio:3,gapWidth:1,splitCharacter:"|",initValue:function(t,e,a){var n=this;n.width=e,n.height=a,n.value=t,n.dataLength=t.length,n.pattern=[],n.patternString=""},prepareValues:function(){var t,e=this,a=e.minBaseUnitLength,n=e.maxRatio,r=e.minRatio,i=Math.max(.15*e.width,24);if(e.height<i)throw new Error("Insufficient Height. The minimum height for value: "+e.value+" is: "+i);for(;(t=e.getBaseUnit(n))<a&&n>r;)n=parseFloat((n-.1).toFixed(1));if(t<a){var s=Math.ceil(e.getBaseWidth(r)*a);throw new Error("Insufficient width. The minimum width for value: "+e.value+" is: "+s)}e.ratio=n,e.baseUnit=t,e.patternString=e.patternString.substring(0,e.patternString.length-1),e.pattern=e.pattern.concat(e.patternString.replace(/ratio/g,n).split(e.splitCharacter))},getBaseUnit:function(t){return this.width/this.getBaseWidth(t)},getBaseWidth:function(t){var e=this,a=3*(t+2);return e.quietZoneLength+a*(e.dataLength+2)+e.gapWidth*(e.dataLength+1)},addStart:function(){var t=this;t.addPattern(t.characterMap.START.pattern),t.addCharacterGap()},addBase:function(t){this.addPattern(t.pattern),this.addCharacterGap()},addStop:function(){this.addPattern(this.characterMap.START.pattern)},addPattern:function(t){for(var e=0;e<t.length;e++)this.patternString+=this.patternMappings[t.charAt(e)]},addCharacterGap:function(){var t=this;t.patternString+=t.gapWidth+t.splitCharacter},patternMappings:{b:"1|",w:"1|",B:"ratio|",W:"ratio|"},characterMap:{0:{pattern:"bwbWBwBwb",value:0},1:{pattern:"BwbWbwbwB",value:1},2:{pattern:"bwBWbwbwB",value:2},3:{pattern:"BwBWbwbwb",value:3},4:{pattern:"bwbWBwbwB",value:4},5:{pattern:"BwbWBwbwb",value:5},6:{pattern:"bwBWBwbwb",value:6},7:{pattern:"bwbWbwBwB",value:7},8:{pattern:"BwbWbwBwb",value:8},9:{pattern:"bwBWbwBwb",value:9},A:{pattern:"BwbwbWbwB",value:10},B:{pattern:"bwBwbWbwB",value:11},C:{pattern:"BwBwbWbwb",value:12},D:{pattern:"bwbwBWbwB",value:13},E:{pattern:"BwbwBWbwb",value:14},F:{pattern:"bwBwBWbwb",value:15},G:{pattern:"bwbwbWBwB",value:16},H:{pattern:"BwbwbWBwb",value:17},I:{pattern:"bwBwbWBwb",value:18},J:{pattern:"bwbwBWBwb",value:19},K:{pattern:"BwbwbwbWB",value:20},L:{pattern:"bwBwbwbWB",value:21},M:{pattern:"BwBwbwbWb",value:22},N:{pattern:"bwbwBwbWB",value:23},O:{pattern:"BwbwBwbWb",value:24},P:{pattern:"bwBwBwbWb",value:25},Q:{pattern:"bwbwbwBWB",value:26},R:{pattern:"BwbwbwBWb",value:27},S:{pattern:"bwBwbwBWb",value:28},T:{pattern:"bwbwBwBWb",value:29},U:{pattern:"BWbwbwbwB",value:30},V:{pattern:"bWBwbwbwB",value:31},W:{pattern:"BWBwbwbwb",value:32},X:{pattern:"bWbwBwbwB",value:33},Y:{pattern:"BWbwBwbwb",value:34},Z:{pattern:"bWBwBwbwb",value:35},"-":{pattern:"bWbwbwBwB",value:36},".":{pattern:"BWbwbwBwb",value:37}," ":{pattern:"bWBwbwBwb",value:38},$:{pattern:"bWbWbWbwb",value:39},"/":{pattern:"bWbWbwbWb",value:40},"+":{pattern:"bWbwbWbWb",value:41},"%":{pattern:"bwbWbWbWb",value:42},START:{pattern:"bWbwBwBwb"}},options:{addCheckSum:!1}}),w.code39extended=w.code39.extend(i({},S,{name:"Code 39 extended",characterMap:{SHIFT0:{pattern:"bWbwbWbWb",value:41},SHIFT1:{pattern:"bWbWbwbWb",value:40},SHIFT2:{pattern:"bWbWbWbwb",value:39},SHIFT3:{pattern:"bwbWbWbWb",value:42}}})),w.code93=m.extend({name:"Code 93",cCheckSumTotal:20,kCheckSumTotal:15,checkSumMod:47,initValue:function(t,e,a){var n=this;n.value=t,n.width=e,n.height=a,n.pattern=[],n.values=[],n.dataLength=t.length},prepareValues:function(){var t=this,e=Math.max(.15*t.width,24);if(t.height<e)throw new Error("Insufficient Height");if(t.setBaseUnit(),t.baseUnit<t.minBaseUnitLength)throw new Error("Insufficient Width")},setBaseUnit:function(){var t=this;t.baseUnit=t.width/(9*(t.dataLength+2+2)+t.quietZoneLength+1)},addStart:function(){var t=this.characterMap.START.pattern;this.addPattern(t)},addStop:function(){var t=this;t.addStart(),t.pattern.push(t.characterMap.TERMINATION_BAR)},addBase:function(t){this.addPattern(t.pattern),this.values.push(t.value)},pushCheckSum:function(){var t,e=this,a=e._getCheckValues();e.checksum=a.join("");for(var n=0;n<a.length;n++)t=e.characterMap[e._findCharacterByValue(a[n])],e.addPattern(t.pattern)},_getCheckValues:function(){var t,e,a=this,n=a.values,r=n.length,i=0;for(e=r-1;e>=0;e--)i+=a.weightedValue(n[e],r-e,a.cCheckSumTotal);for(t=i%a.checkSumMod,i=a.weightedValue(t,1,a.kCheckSumTotal),e=r-1;e>=0;e--)i+=a.weightedValue(n[e],r-e+1,a.kCheckSumTotal);return[t,i%a.checkSumMod]},_findCharacterByValue:function(t){for(var e in this.characterMap)if(this.characterMap[e].value===t)return e},weightedValue:function(t,e,a){return(e%a||a)*t},addPattern:function(t){for(var e,a=0;a<t.length;a++)e=parseInt(t.charAt(a),10),this.pattern.push(e)},characterMap:{0:{pattern:"131112",value:0},1:{pattern:"111213",value:1},2:{pattern:"111312",value:2},3:{pattern:"111411",value:3},4:{pattern:"121113",value:4},5:{pattern:"121212",value:5},6:{pattern:"121311",value:6},7:{pattern:"111114",value:7},8:{pattern:"131211",value:8},9:{pattern:"141111",value:9},A:{pattern:"211113",value:10},B:{pattern:"211212",value:11},C:{pattern:"211311",value:12},D:{pattern:"221112",value:13},E:{pattern:"221211",value:14},F:{pattern:"231111",value:15},G:{pattern:"112113",value:16},H:{pattern:"112212",value:17},I:{pattern:"112311",value:18},J:{pattern:"122112",value:19},K:{pattern:"132111",value:20},L:{pattern:"111123",value:21},M:{pattern:"111222",value:22},N:{pattern:"111321",value:23},O:{pattern:"121122",value:24},P:{pattern:"131121",value:25},Q:{pattern:"212112",value:26},R:{pattern:"212211",value:27},S:{pattern:"211122",value:28},T:{pattern:"211221",value:29},U:{pattern:"221121",value:30},V:{pattern:"222111",value:31},W:{pattern:"112122",value:32},X:{pattern:"112221",value:33},Y:{pattern:"122121",value:34},Z:{pattern:"123111",value:35},"-":{pattern:"121131",value:36},".":{pattern:"311112",value:37}," ":{pattern:"311211",value:38},$:{pattern:"321111",value:39},"/":{pattern:"112131",value:40},"+":{pattern:"113121",value:41},"%":{pattern:"211131",value:42},SHIFT0:{pattern:"122211",value:46},SHIFT1:{pattern:"311121",value:45},SHIFT2:{pattern:"121221",value:43},SHIFT3:{pattern:"312111",value:44},START:{pattern:"111141"},TERMINATION_BAR:"1"}}),w.code93extended=w.code93.extend(i({},S,{name:"Code 93 extended",pushCheckSum:function(){var t,e=this,a=e._getCheckValues();e.checksum=a.join("");for(var n=0;n<a.length;n++)t=a[n],e.shiftValuesAsciiCodes[t]?e.addExtended(e.shiftValuesAsciiCodes[t]):e.addPattern(e.characterMap[e._findCharacterByValue(t)].pattern)}}));var C=a.Class.extend({init:function(t){this.encoding=t},addStart:function(){},is:function(){},move:function(){},pushState:function(){}}),B=C.extend({FNC4:"FNC4",init:function(t,e){var a=this;a.encoding=t,a.states=e,a._initMoves(e)},addStart:function(){this.encoding.addPattern(this.START)},is:function(t,e){var a=t.charCodeAt(e);return this.isCode(a)},move:function(t){for(var e=this,a=0;!e._moves[a].call(e,t)&&a<e._moves.length;)a++},pushState:function(t){var e,a=this,n=a.states,r=t.value,i=r.length;if(s("C",n)>=0){var o=r.substr(t.index).match(/\d{4,}/g);o&&(i=r.indexOf(o[0],t.index))}for(;(e=t.value.charCodeAt(t.index))>=0&&a.isCode(e)&&t.index<i;)a.encoding.addPattern(a.getValue(e)),t.index++},_initMoves:function(t){var e=this;e._moves=[],s(e.FNC4,t)>=0&&e._moves.push(e._moveFNC),s(e.shiftKey,t)>=0&&e._moves.push(e._shiftState),e._moves.push(e._moveState)},_moveFNC:function(t){if(t.fnc)return t.fnc=!1,t.previousState==this.key},_shiftState:function(t){var e=this;if(t.previousState==e.shiftKey&&(t.index+1>=t.value.length||e.encoding[e.shiftKey].is(t.value,t.index+1)))return e.encoding.addPattern(e.SHIFT),t.shifted=!0,!0},_moveState:function(){return this.encoding.addPattern(this.MOVE),!0},SHIFT:98}),x={};x.A=B.extend({key:"A",shiftKey:"B",isCode:function(t){return t>=0&&t<96},getValue:function(t){return t<32?t+64:t-32},MOVE:101,START:103}),x.B=B.extend({key:"B",shiftKey:"A",isCode:function(t){return t>=32&&t<128},getValue:function(t){return t-32},MOVE:100,START:104}),x.C=C.extend({key:"C",addStart:function(){this.encoding.addPattern(this.START)},is:function(t,e){var a=g(t,e,4);return(e+4<=t.length||2==t.length)&&v.test(a)},move:function(){this.encoding.addPattern(this.MOVE)},pushState:function(t){for(var e;(e=g(t.value,t.index,2))&&v.test(e)&&2==e.length;)this.encoding.addPattern(parseInt(e,10)),t.index+=2},getValue:function(t){return t},MOVE:99,START:105}),x.FNC4=C.extend({key:"FNC4",dependentStates:["A","B"],init:function(t,e){this.encoding=t,this._initSubStates(e)},addStart:function(t){var e=t.value.charCodeAt(0)-128,a=this._getSubState(e);this.encoding[a].addStart()},is:function(t,e){var a=t.charCodeAt(e);return this.isCode(a)},isCode:function(t){return t>=128&&t<256},pushState:function(t){var e=this,a=e._initSubState(t),n=e.encoding,r=a.value.length;if(t.index+=r,r<3)for(var i;a.index<r;a.index++)i=a.value.charCodeAt(a.index),a.state=e._getSubState(i),a.previousState!=a.state&&(a.previousState=a.state,n[a.state].move(a)),n.addPattern(n[a.state].MOVE),n.addPattern(n[a.state].getValue(i));else a.state!=a.previousState&&n[a.state].move(a),e._pushStart(a),n.pushData(a,e.subStates),t.index<t.value.length&&e._pushStart(a);t.fnc=!0,t.state=a.state},_pushStart:function(t){var e=this;e.encoding.addPattern(e.encoding[t.state].MOVE),e.encoding.addPattern(e.encoding[t.state].MOVE)},_initSubState:function(t){var e=this,a={value:e._getAll(t.value,t.index),index:0};return a.state=e._getSubState(a.value.charCodeAt(0)),a.previousState=t.previousState==e.key?a.state:t.previousState,a},_initSubStates:function(t){var e=this;e.subStates=[];for(var a=0;a<t.length;a++)s(t[a],e.dependentStates)>=0&&e.subStates.push(t[a])},_getSubState:function(t){for(var e=this,a=0;a<e.subStates.length;a++)if(e.encoding[e.subStates[a]].isCode(t))return e.subStates[a]},_getAll:function(t,e){for(var a,n="";(a=t.charCodeAt(e++))&&this.isCode(a);)n+=String.fromCharCode(a-128);return n}}),x.FNC1=C.extend({key:"FNC1",startState:"C",dependentStates:["C","B"],startAI:"(",endAI:")",init:function(t,e){this.encoding=t,this.states=e},addStart:function(){this.encoding[this.startState].addStart()},is:function(){return s(this.key,this.states)>=0},pushState:function(t){var e,a,n,r=this,i=r.encoding,s=t.value.replace(/\s/g,""),o=new RegExp("["+r.startAI+r.endAI+"]","g"),h=t.index,d={state:r.startState};for(i.addPattern(r.START);;){if(d.index=0,(e=(n=s.charAt(h)===r.startAI?2:0)>0?r.getBySeparator(s,h):r.getByLength(s,h)).ai.length)a=h+n+e.id.length+e.ai.length;else if((a=s.indexOf(r.startAI,h+1))<0){if(h+e.ai.max+e.id.length+n<s.length)throw new Error("Separators are required after variable length identifiers");a=s.length}if(d.value=s.substring(h,a).replace(o,""),r.validate(e,d.value),i.pushData(d,r.dependentStates),a>=s.length)break;h=a,d.state!=r.startState&&(i[r.startState].move(d),d.state=r.startState),e.ai.length||i.addPattern(r.START)}t.index=t.value.length},validate:function(t,e){var a=e.substr(t.id.length),n=t.ai;if(!n.type&&!v.test(a))throw new Error("Application identifier "+t.id+" is numeric only but contains non numeric character(s).");if("alphanumeric"==n.type&&!f.test(a))throw new Error("Application identifier "+t.id+" is alphanumeric only but contains non alphanumeric character(s).");if(n.length&&n.length!==a.length)throw new Error("Application identifier "+t.id+" must be "+n.length+" characters long.");if(n.min&&n.min>a.length)throw new Error("Application identifier "+t.id+" must be at least "+n.min+" characters long.");if(n.max&&n.max<a.length)throw new Error("Application identifier "+t.id+" must be at most "+n.max+" characters long.")},getByLength:function(t,e){for(var a,n,r=this,i=2;i<=4;i++)if(a=g(t,e,i),n=r.getAI(a)||r.getAI(a.substring(0,a.length-1)))return{id:a,ai:n};r.unsupportedAIError(a)},unsupportedAIError:function(t){throw new Error(a.format("'{0}' is not a supported Application Identifier"),t)},getBySeparator:function(t,e){var a=this,n=t.indexOf(a.startAI,e),r=t.indexOf(a.endAI,n),i=t.substring(n+1,r),s=a.getAI(i)||a.getAI(i.substr(i.length-1));return s||a.unsupportedAIError(i),{ai:s,id:i}},getAI:function(t){var e=this.applicationIdentifiers,a=e.multiKey;if(e[t])return e[t];for(var n=0;n<a.length;n++){if(a[n].ids&&s(t,a[n].ids)>=0)return a[n].type;if(a[n].ranges)for(var r=a[n].ranges,i=0;i<r.length;i++)if(r[i][0]<=t&&t<=r[i][1])return a[n].type}},applicationIdentifiers:{22:{max:29,type:"alphanumeric"},402:{length:17},7004:{max:4,type:"alphanumeric"},242:{max:6,type:"alphanumeric"},8020:{max:25,type:"alphanumeric"},703:{min:3,max:30,type:"alphanumeric"},8008:{min:8,max:12,type:"alphanumeric"},253:{min:13,max:17,type:"alphanumeric"},8003:{min:14,max:30,type:"alphanumeric"},multiKey:[{ids:["15","17","8005","8100"],ranges:[[11,13],[310,316],[320,336],[340,369]],type:{length:6}},{ids:["240","241","250","251","400","401","403","7002","8004","8007","8110"],ranges:[[-9]],type:{max:30,type:"alphanumeric"}},{ids:["7001"],ranges:[[410,414]],type:{length:13}},{ids:["10","21","254","420","8002"],type:{max:20,type:"alphanumeric"}},{ids:["00","8006","8017","8018"],type:{length:18}},{ids:["01","02","8001"],type:{length:14}},{ids:["422"],ranges:[[424,426]],type:{length:3}},{ids:["20","8102"],type:{length:2}},{ids:["30","37"],type:{max:8,type:"alphanumeric"}},{ids:["390","392"],type:{max:15,type:"alphanumeric"}},{ids:["421","423"],type:{min:3,max:15,type:"alphanumeric"}},{ids:["391","393"],type:{min:3,max:18,type:"alphanumeric"}},{ids:["7003","8101"],type:{length:10}}]},START:102});var k=b.extend({init:function(t){b.fn.init.call(this,t),this._initStates()},_initStates:function(){for(var t=this,e=0;e<t.states.length;e++)t[t.states[e]]=new x[t.states[e]](t,t.states)},initValue:function(t,e,a){var n=this;n.pattern=[],n.value=t,n.width=e,n.height=a,n.checkSum=0,n.totalUnits=0,n.index=0,n.position=1},addData:function(){var t=this,e={value:t.value,index:0,state:""};0!==t.value.length&&(e.state=e.previousState=t.getNextState(e,t.states),t.addStart(e),t.pushData(e,t.states),t.addCheckSum(),t.addStop(),t.setBaseUnit())},pushData:function(t,e){for(var a=this;a[t.state].pushState(t),!(t.index>=t.value.length);)if(t.shifted){var n=t.state;t.state=t.previousState,t.previousState=n,t.shifted=!1}else t.previousState=t.state,t.state=a.getNextState(t,e),a[t.state].move(t)},addStart:function(t){this[t.state].addStart(t),this.position=1},addCheckSum:function(){var t=this;t.checksum=t.checkSum%103,t.addPattern(t.checksum)},addStop:function(){this.addPattern(this.STOP)},setBaseUnit:function(){var t=this;t.baseUnit=t.width/(t.totalUnits+t.quietZoneLength)},addPattern:function(t){for(var e,a=this,n=a.characterMap[t].toString(),r=0;r<n.length;r++)e=parseInt(n.charAt(r),10),a.pattern.push(e),a.totalUnits+=e;a.checkSum+=t*a.position++},getNextState:function(t,e){for(var a=0;a<e.length;a++)if(this[e[a]].is(t.value,t.index))return e[a];this.invalidCharacterError(t.value.charAt(t.index))},characterMap:[212222,222122,222221,121223,121322,131222,122213,122312,132212,221213,221312,231212,112232,122132,122231,113222,123122,123221,223211,221132,221231,213212,223112,312131,311222,321122,321221,312212,322112,322211,212123,212321,232121,111323,131123,131321,112313,132113,132311,211313,231113,231311,112133,112331,132131,113123,113321,133121,313121,211331,231131,213113,213311,213131,311123,311321,331121,312113,312311,332111,314111,221411,431111,111224,111422,121124,121421,141122,141221,112214,112412,122114,122411,142112,142211,241211,221114,413111,241112,134111,111242,121142,121241,114212,124112,124211,411212,421112,421211,212141,214121,412121,111143,111341,131141,114113,114311,411113,411311,113141,114131,311141,411131,211412,211214,211232,2331112],STOP:106});w.code128a=k.extend({name:"Code 128 A",states:["A"]}),w.code128b=k.extend({name:"Code 128 B",states:["B"]}),w.code128c=k.extend({name:"Code 128 C",states:["C"]}),w.code128=k.extend({name:"Code 128",states:["C","B","A","FNC4"]}),w["gs1-128"]=k.extend({name:"Code GS1-128",states:["FNC1","C","B"]});var A=b.extend({initValue:function(t,e){var a=this;a.pattern=[],a.value=t,a.checkSumLength=0,a.width=e},setBaseUnit:function(){var t=this;t.baseUnit=t.width/(12*(t.value.length+t.checkSumLength)+t.quietZoneLength+7)},addData:function(){var t=this,e=t.value;t.addPattern(t.START);for(var a=0;a<e.length;a++)t.addCharacter(e.charAt(a));t.options.addCheckSum&&t.addCheckSum(),t.addPattern(t.STOP),t.setBaseUnit()},addCharacter:function(t){var e=this,a=e.characterMap[t];a||e.invalidCharacterError(t),e.addPattern(a)},addPattern:function(t){for(var e=0;e<t.length;e++)this.pattern.push(parseInt(t.charAt(e),10))},addCheckSum:function(){var t,e=this;t=e.checkSums[e.checkSumType].call(e.checkSums,e.value),e.checksum=t.join("");for(var a=0;a<t.length;a++)e.checkSumLength++,e.addPattern(e.characterMap[t[a]])},checkSums:{Modulo10:function(t){var e,a,n,r=[0,""],i=t.length%2;for(e=0;e<t.length;e++)r[(e+i)%2]+=parseInt(t.charAt(e),10);for(n=r[0],a=(2*r[1]).toString(),e=0;e<a.length;e++)n+=parseInt(a.charAt(e),10);return[(10-n%10)%10]},Modulo11:function(t){for(var e,a=0,n=t.length,r=0;r<n;r++)a+=(((n-r)%6||6)+1)*t.charAt(r);return 10!=(e=(11-a%11)%11)?[e]:[1,0]},Modulo11Modulo10:function(t){var e,a=this.Modulo11(t);return e=t+a[0],a.concat(this.Modulo10(e))},Modulo10Modulo10:function(t){var e,a=this.Modulo10(t);return e=t+a[0],a.concat(this.Modulo10(e))}},characterMap:["12121212","12121221","12122112","12122121","12211212","12211221","12212112","12212121","21121212","21121221"],START:"21",STOP:"121",checkSumType:""});w.msimod10=A.extend({name:"MSI Modulo10",checkSumType:"Modulo10"}),w.msimod11=A.extend({name:"MSI Modulo11",checkSumType:"Modulo11"}),w.msimod1110=A.extend({name:"MSI Modulo11 Modulo10",checkSumType:"Modulo11Modulo10"}),w.msimod1010=A.extend({name:"MSI Modulo10 Modulo10",checkSumType:"Modulo10Modulo10"}),w.code11=b.extend({name:"Code 11",cCheckSumTotal:10,kCheckSumTotal:9,kCheckSumMinLength:10,checkSumMod:11,DASH_VALUE:10,DASH:"-",START:"112211",STOP:"11221",initValue:function(t,e){var a=this;a.pattern=[],a.value=t,a.width=e,a.totalUnits=0},addData:function(){var t=this,e=t.value;t.addPattern(t.START);for(var a=0;a<e.length;a++)t.addCharacter(e.charAt(a));t.options.addCheckSum&&t.addCheckSum(),t.addPattern(t.STOP),t.setBaseUnit()},setBaseUnit:function(){var t=this;t.baseUnit=t.width/(t.totalUnits+t.quietZoneLength)},addCheckSum:function(){var t,e=this,a=e.value,n=a.length;if(t=e.getWeightedSum(a,n,e.cCheckSumTotal)%e.checkSumMod,e.checksum=t+"",e.addPattern(e.characterMap[t]),++n>=e.kCheckSumMinLength){var r=(t+e.getWeightedSum(a,n,e.kCheckSumTotal))%e.checkSumMod;e.checksum+=r,e.addPattern(e.characterMap[r])}},getWeightedSum:function(t,e,a){for(var n=0,r=0;r<t.length;r++)n+=this.weightedValue(this.getValue(t.charAt(r)),e,r,a);return n},weightedValue:function(t,e,a,n){return((e-a)%n||n)*t},getValue:function(t){var e=this;return isNaN(t)?(t!==e.DASH&&e.invalidCharacterError(t),e.DASH_VALUE):parseInt(t,10)},addCharacter:function(t){var e=this,a=e.getValue(t),n=e.characterMap[a];e.addPattern(n)},addPattern:function(t){for(var e,a=0;a<t.length;a++)e=parseInt(t.charAt(a),10),this.pattern.push(e),this.totalUnits+=e},characterMap:["111121","211121","121121","221111","112121","212111","122111","111221","211211","211111","112111"],options:{addCheckSum:!0}}),w.postnet=b.extend({name:"Postnet",START:"2",VALID_CODE_LENGTHS:[5,9,11],DIGIT_SEPARATOR:"-",initValue:function(t,e,a){var n=this;n.height=a,n.width=e,n.baseHeight=a/2,n.value=t.replace(new RegExp(n.DIGIT_SEPARATOR,"g"),""),n.pattern=[],n.validate(n.value),n.checkSum=0,n.setBaseUnit()},addData:function(){var t=this,e=t.value;t.addPattern(t.START);for(var a=0;a<e.length;a++)t.addCharacter(e.charAt(a));t.options.addCheckSum&&t.addCheckSum(),t.addPattern(t.START),t.pattern.pop()},addCharacter:function(t){var e=this,a=e.characterMap[t];e.checkSum+=parseInt(t,10),e.addPattern(a)},addCheckSum:function(){var t=this;t.checksum=(10-t.checkSum%10)%10,t.addCharacter(t.checksum)},setBaseUnit:function(){var t=this;t.baseUnit=t.width/(10*(t.value.length+1)+3+t.quietZoneLength)},validate:function(t){var e=this;if(v.test(t)||e.invalidCharacterError(t.match(/[^0-9]/)[0]),s(t.length,e.VALID_CODE_LENGTHS)<0)throw new Error("Invalid value length. Valid lengths for the Postnet symbology are "+e.VALID_CODE_LENGTHS.join(","))},addPattern:function(t){for(var e,a=this,n=0;n<t.length;n++)e=a.height-a.baseHeight*t.charAt(n),a.pattern.push({width:1,y1:e,y2:a.height}),a.pattern.push(1)},characterMap:["22111","11122","11212","11221","12112","12121","12211","21112","21121","21211"]}),w.ean13=b.extend({initValue:function(t,e,a){if(12!=(t+="").length||/\D/.test(t))throw new Error('The value of the "EAN13" encoding should be 12 symbols');var n=this;n.pattern=[],n.options.height=a,n.baseUnit=e/(95+n.quietZoneLength),n.value=t,n.checksum=n.calculateChecksum(),n.leftKey=t[0],n.leftPart=t.substr(1,6),n.rightPart=t.substr(7)+n.checksum},addData:function(){var t=this;t.addPieces(t.characterMap.start),t.addSide(t.leftPart,t.leftKey),t.addPieces(t.characterMap.middle),t.addSide(t.rightPart),t.addPieces(t.characterMap.start)},addSide:function(t,e){for(var a=this,n=0;n<t.length;n++)e&&parseInt(a.keyTable[e].charAt(n),10)?a.addPieces(Array.prototype.slice.call(a.characterMap.digits[t.charAt(n)]).reverse(),!0):a.addPieces(a.characterMap.digits[t.charAt(n)],!0)},addPieces:function(t,e){for(var a=this,n=0;n<t.length;n++)e?a.pattern.push({y1:0,y2:.95*a.options.height,width:t[n]}):a.pattern.push(t[n])},calculateChecksum:function(){for(var t=0,e=0,a=this.value.split("").reverse().join(""),n=0;n<a.length;n++)n%2?e+=parseInt(a.charAt(n),10):t+=parseInt(a.charAt(n),10);return(10-(3*t+e)%10)%10},keyTable:["000000","001011","001101","001110","010011","011001","011100","010101","010110","011010"],characterMap:{digits:[[3,2,1,1],[2,2,2,1],[2,1,2,2],[1,4,1,1],[1,1,3,2],[1,2,3,1],[1,1,1,4],[1,3,1,2],[1,2,1,3],[3,1,1,2]],start:[1,1,1],middle:[1,1,1,1,1]}}),w.ean8=w.ean13.extend({initValue:function(t,e,a){var n=this;if(7!=t.length||/\D/.test(t))throw new Error("Invalid value provided");n.value=t,n.options.height=a,n.checksum=n.calculateChecksum(n.value),n.leftPart=n.value.substr(0,4),n.rightPart=n.value.substr(4)+n.checksum,n.pattern=[],n.baseUnit=e/(67+n.quietZoneLength)}});var M=n.extend({init:function(e,a){var r=this;n.fn.init.call(r,e,a),r.element=t(e),r.wrapper=r.element,r.element.addClass("k-barcode").css("display","block"),r.surfaceWrap=t("<div />").css("position","relative").appendTo(this.element),r.surface=h.Surface.create(r.surfaceWrap,{type:r.options.renderAs}),r._setOptions(a),a&&u(a.value)&&r.redraw()},setOptions:function(t){this._setOptions(t),this.redraw()},redraw:function(){var t=this._getSize();this.surface.clear(),this.surface.setSize({width:t.width,height:t.height}),this.createVisual(),this.surface.draw(this.visual)},getSize:function(){return a.dimensions(this.element)},_resize:function(){this.redraw()},createVisual:function(){this.visual=this._render()},_render:function(){var t,e,a=this,n=a.options,r=n.value,i=n.text,s=c.getSpacing(i.margin),o=a._getSize(),d=n.border||{},p=a.encoding,v=new l(0,0,o.width,o.height).unpad(d.width).unpad(n.padding),f=v.height(),g=new h.Group;return a.contentBox=v,g.append(a._getBackground(o)),i.visible&&(f-=h.util.measureText(r,{font:i.font}).height+s.top+s.bottom),t=p.encode(r,v.width(),f),i.visible&&(e=r,n.checksum&&u(p.checksum)&&(e+=" "+p.checksum),g.append(a._getText(e))),a.barHeight=f,this._bandsGroup=this._getBands(t.pattern,t.baseUnit),g.append(this._bandsGroup),g},exportVisual:function(){return this._render()},_getSize:function(){var t=this,e=t.element,a=new d.Size(300,100);return e.width()>0&&(a.width=e.width()),e.height()>0&&(a.height=e.height()),t.options.width&&(a.width=t.options.width),t.options.height&&(a.height=t.options.height),a},value:function(t){var e=this;if(!u(t))return e.options.value;e.options.value=t+"",e.redraw()},_getBands:function(t,e){for(var a,n,r=this,i=r.contentBox,s=i.x1,u=new h.Group,c=0;c<t.length;c++){if(a=(n=o(t[c])?t[c]:{width:t[c],y1:0,y2:r.barHeight}).width*e,c%2){var l=d.Rect.fromPoints(new d.Point(s,n.y1+i.y1),new d.Point(s+a,n.y2+i.y1)),p=h.Path.fromRect(l,{fill:{color:r.options.color},stroke:null});u.append(p)}s+=a}return u},_getBackground:function(t){var e=this.options,a=e.border||{},n=new l(0,0,t.width,t.height).unpad(a.width/2);return h.Path.fromRect(n.toRect(),{fill:{color:e.background},stroke:{color:a.width?a.color:"",width:a.width,dashType:a.dashType}})},_getText:function(t){var e=this,a=e.options.text,n=e._textbox=new p(t,{font:a.font,color:a.color,align:"center",vAlign:"bottom",margin:a.margin});return n.reflow(e.contentBox),n.renderVisual(),n.visual},_setOptions:function(t){var e=this;if(e.type=(t.type||e.options.type).toLowerCase(),"upca"==e.type&&(e.type="ean13",t.value="0"+t.value),"upce"==e.type&&(e.type="ean8",t.value="0"+t.value),!w[e.type])throw new Error("Encoding "+e.type+"is not supported.");e.encoding=new w[e.type],e.options=r(!0,e.options,t)},options:{name:"Barcode",renderAs:"svg",value:"",type:"code39",checksum:!1,width:0,height:0,color:"black",background:"white",text:{visible:!0,font:"16px Consolas, Monaco, Sans Mono, monospace, sans-serif",color:"black",margin:{top:0,bottom:0,left:0,right:0}},border:{width:0,dashType:"solid",color:"black"},padding:{top:0,bottom:0,left:0,right:0}}});c.ExportMixin.extend(M.fn),c.ui.plugin(M),a.deepExtend(c,{encodings:w,Encoding:b})}(window.kendo.jQuery);var kendo$1=kendo;export{kendo$1 as default};
//# sourceMappingURL=kendo.dataviz.barcode.js.map