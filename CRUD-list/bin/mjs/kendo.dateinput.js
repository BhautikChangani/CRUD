/**
 * Kendo UI v2024.2.514 (http://www.telerik.com/kendo-ui)
 * Copyright 2024 Progress Software Corporation and/or one of its subsidiaries or affiliates. All rights reserved.
 *
 * Kendo UI commercial licenses may be obtained at
 * http://www.telerik.com/purchase/license-agreement/kendo-ui-complete
 * If you do not own a commercial license, this file shall be governed by the trial license terms.
 */
import"./kendo.core.js";import"./kendo.label.js";import"./kendo.icons.js";import"./kendo.dateinput.common.js";var __meta__={id:"dateinput",name:"DateInput",category:"web",description:"The DateInput widget allows to edit date by typing.",depends:["core","label"]};!function(e,t){var n=window.kendo,a=n.ui,i=a.Widget,s=a.DateInputCommon,o=".kendoDateInput",l={}.toString,r=e.isPlainObject,u="k-focus",d="k-disabled",c="k-invalid",p="disabled",m="readonly",f="change",h=n.Class.extend({init:function(e){const t=e.culture?n.getCulture(e.culture):n.culture();this.messages=e.messages,this.cldr={},this.cldr[t.name]={name:t.name,calendar:t.calendar||{},numbers:t.numberFormat}},parseDate:function(e,t,a){return n.parseDate(e,t,a,!0)},formatDate:function(e,t,a){return n.toString(e,t,a)},splitDateFormat:function(e){return n.date.splitDateFormat(e)},dateFormatNames:function(e,t){return n.date.dateFormatNames(t)},dateFieldName:function(e){return this.messages[e.type]||{}}});function v(){const e=n.culture();let t=[];return t.push(e.calendars.standard["/"]),t.push(e.calendars.standard[":"]),t}function b(e,t){if(!e)return t;return n.getCulture(e).calendars.standard.patterns[t]||t}var g=i.extend({init:function(t,a){var l=this;i.fn.init.call(l,t,a),t=l.element,(a=l.options).format=n._extractFormat(a.format||n.getCulture(a.culture).calendars.standard.patterns.d),a.min=n.parseDate(t.attr("min"))||n.parseDate(a.min),a.max=n.parseDate(t.attr("max"))||n.parseDate(a.max);var r=t.parent().attr("class")||"",d=r.indexOf("picker")>=0&&r.indexOf("rangepicker")<0,c=l.options.value||t.val();d?l.wrapper=l.element.parent():(l.wrapper=t.wrap("<span class='k-dateinput k-input'></span>").parent(),l.wrapper.addClass(t[0].className).removeClass("input-validation-error")),l.wrapper[0].style.cssText=t[0].style.cssText,t.css({height:t[0].style.height}),l._validationIcon=e(n.ui.icon({icon:"exclamation-circle",iconClass:"k-input-validation-icon k-hidden"})).insertAfter(t),l._form(),l.dateInputInstance=new s(t[0],{format:b(a.culture,a.format),autoCorrectParts:a.autoCorrectParts,autoSwitchKeys:a.autoSwitchKeys.length?a.autoSwitchKeys:v(),enableMouseWheel:a.enableMouseWheel,twoDigitYearMax:a.twoDigitYearMax,steps:a.steps,formatPlaceholder:a.messages,events:{inputEnd:function(e){e.error&&l._blinkInvalidState()},keydown:function(e){e.event.keyCode!=n.keys.UP&&e.event.keyCode!=n.keys.DOWN||setTimeout((function(){l.element.trigger(f)}))},blur:function(e){l._change(),e.preventDefault()}},intlService:new h({culture:a.culture,messages:l.options.messages}),autoSwitchParts:a.autoSwitchParts,autoFill:a.autoFill}),l._emptyMask=this.element.val(),a.value&&l.value(a.value),l.element.addClass("k-input-inner").attr("autocomplete","off").on("focus"+o,(function(){l.wrapper.addClass(u)})).on("focusout"+o,(function(){l.wrapper.removeClass(u)}));try{t[0].setAttribute("type","text")}catch(e){t[0].type="text"}t.is("[disabled]")||e(l.element).parents("fieldset").is(":disabled")?l.enable(!1):l.readonly(t.is("[readonly]")),l.value(c),d||l._applyCssClasses(),a.label&&l._label(),n.notify(l)},options:{name:"DateInput",autoCorrectParts:!0,autoSwitchKeys:[],autoSwitchParts:!1,enableMouseWheel:!0,culture:"",value:"",format:"",min:new Date(1900,0,1),max:new Date(2099,11,31),messages:{year:"year",month:"month",day:"day",weekday:"day of the week",hour:"hours",minute:"minutes",second:"seconds",milliseconds:"milliseconds",dayperiod:"AM/PM"},size:"medium",steps:{year:1,month:1,day:1,hour:1,minute:1,second:1,millisecond:1},fillMode:"solid",rounded:"medium",label:null,autoFill:!1},events:[f],min:function(e){if(e===t)return this.options.min;this.options.min=e},max:function(e){if(e===t)return this.options.max;this.options.max=e},setOptions:function(e){var t=this;i.fn.setOptions.call(t,e),t.dateInputInstance.destroy(),t.dateInputInstance=null,t.dateInputInstance=new s(this.element[0],{format:b(t.options.culture,t.options.format),autoSwitchKeys:t.options.autoSwitchKeys.length?t.options.autoSwitchKeys:v(),autoCorrectParts:t.options.autoCorrectParts,enableMouseWheel:t.options.enableMouseWheel,steps:t.options.steps,twoDigitYearMax:t.options.twoDigitYearMax,formatPlaceholder:t.options.messages,events:{inputEnd:function(e){e.error&&t._blinkInvalidState()},keydown:function(e){e.event.keyCode!=n.keys.UP&&e.event.keyCode!=n.keys.DOWN||setTimeout((function(){t.element.trigger(f)}))},blur:function(e){t._change(),e.preventDefault()}},intlService:new h({culture:t.options.culture,messages:t.options.messages}),autoSwitchParts:t.options.autoSwitchParts,autoFill:t.options.autoFill})},destroy:function(){var e=this;e.element.off(o),e.dateInputInstance.destroy(),e._formElement&&e._formElement.off("reset",e._resetHandler),e.label&&e.label.destroy(),e._validationIcon&&e._validationIcon.remove(),i.fn.destroy.call(e)},value:function(e){if(e===t)return this.dateInputInstance.value;null===e&&(e=""),"[object Date]"!==l.call(e)&&(e=n.parseDate(e,this.options.format,this.options.culture)),e&&!e.getTime()&&(e=null),this.dateInputInstance.writeValue(e),this.label&&this.label.floatingLabel&&this.label.floatingLabel.refresh()},_hasDateInput:function(){return this._emptyMask!==this.element.val()},readonly:function(e){this._editable({readonly:e===t||e,disable:!1}),this.label&&this.label.floatingLabel&&this.label.floatingLabel.readonly(e===t||e)},enable:function(e){this._editable({readonly:!1,disable:!(e=e===t||e)}),this.label&&this.label.floatingLabel&&this.label.floatingLabel.enable(e=e===t||e)},_label:function(){var t=this,a=t.options,i=r(a.label)?a.label:{content:a.label};t.label=new n.ui.Label(null,e.extend({},i,{widget:t,floatCheck:()=>!(t.value()||t._hasDateInput()&&""!==t.element.val()||document.activeElement===t.element[0])&&(this.element.val(""),!0)})),t._inputLabel=t.label.element},_bindInput:function(){var e=this;e.element.on("focus"+o,(function(){e.wrapper.addClass(u)})).on("focusout"+o,(function(){e.wrapper.removeClass(u)})),this.dateInputInstance&&this.dateInputInstance.bindEvents()},_unbindInput:function(){this.element.off("focus"+o).off("focusout"+o),this.dateInputInstance&&this.dateInputInstance.unbindEvents()},_editable:function(e){var t=this,n=t.element,a=e.disable,i=e.readonly,s=t.wrapper;t._unbindInput(),i||a?(a&&(s.addClass(d),n.attr(p,a),n&&n.length&&n[0].removeAttribute(m)),i&&n.attr(m,i)):(s.removeClass(d),n&&n.length&&(n[0].removeAttribute(p),n[0].removeAttribute(m)),t._bindInput())},_change:function(){var e=this,t=e._oldValue,n=e.value();n&&e.min()&&n<e.min()&&(e.value(e.min()),n=e.value()),n&&e.max()&&n>e.max()&&(e.value(e.max()),n=e.value()),(t&&n&&n.getTime()!==t.getTime()||t&&!n||!t&&n)&&(e._oldValue=n,e.trigger(f,{blur:!0}),e.element.trigger(f))},_blinkInvalidState:function(){var e=this;e._addInvalidState(),clearTimeout(e._invalidStateTimeout),e._invalidStateTimeout=setTimeout(e._removeInvalidState.bind(e),100)},_addInvalidState:function(){this.wrapper.addClass(c),this._validationIcon.removeClass("k-hidden")},_removeInvalidState:function(){var e=this;e.wrapper.removeClass(c),e._validationIcon.addClass("k-hidden"),e._invalidStateTimeout=null},_form:function(){var t=this,n=t.element,a=n.attr("form"),i=a?e("#"+a):n.closest("form"),s=n[0].value;!s&&t.options.value&&(s=t.options.value),i[0]&&(t._resetHandler=function(){setTimeout((function(){t.value(s)}))},t._formElement=i.on("reset",t._resetHandler))},_paste:function(e){e.preventDefault()}});n.cssProperties.registerPrefix("DateInput","k-input-"),n.cssProperties.registerValues("DateInput",[{prop:"rounded",values:n.cssProperties.roundedValues.concat([["full","full"]])}]),a.plugin(g)}(window.kendo.jQuery);var kendo$1=kendo;export{kendo$1 as default};
//# sourceMappingURL=kendo.dateinput.js.map
