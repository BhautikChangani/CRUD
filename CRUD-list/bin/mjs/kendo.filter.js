/**
 * Kendo UI v2024.2.514 (http://www.telerik.com/kendo-ui)
 * Copyright 2024 Progress Software Corporation and/or one of its subsidiaries or affiliates. All rights reserved.
 *
 * Kendo UI commercial licenses may be obtained at
 * http://www.telerik.com/purchase/license-agreement/kendo-ui-complete
 * If you do not own a commercial license, this file shall be governed by the trial license terms.
 */
import"./kendo.core.js";import"./kendo.buttongroup.js";import"./kendo.icons.js";import"./kendo.toolbar.js";var __meta__={id:"filter",name:"Filter",category:"web",depends:["core","buttongroup","icons","toolbar"]},defaultValues={number:0,boolean:!1,string:"",date:""},mainContainer=e=>`<ul class='k-filter-container' role='tree' aria-label='${e}'><li class='k-filter-group-main' role='treeitem'></li></ul>`,mainLogicTemplate=({mainFilterLogicLabel:e,uid:t})=>`<div class='k-filter-toolbar'><div class='k-toolbar' aria-label='${e}' id='${t}'></div></div>`,logicItemTemplate=({filterLogicLabel:e})=>`<li class='k-filter-item' role='treeitem'><div class='k-filter-toolbar'><div role='toolbar' aria-label='${e}' class='k-toolbar'></div></div></li>`,expressionItemTemplate=({filterExpressionLabel:e,uid:t})=>`<li class='k-filter-item' role='treeitem'><div class='k-filter-toolbar'><div role='group' aria-label='${e}' class='k-toolbar' id='${t}'></div></div></li>`;!function(e){var t=window.kendo,o=t.ui,i=t.guid,r=t.ns,s=t.keys,l=o.Widget,a=o.ButtonGroup,n=":kendoFocusable",d="change",p="tabindex",f=".kendoFilter",u="Is equal to",c="Is not equal to",m={number:function(t,{field:o}){e(`<input tabindex='-1' id='${i()}' type='text' aria-label='${o}' title='${o}' data-${r}role='numerictextbox' data-${r}bind='value: value'/>`).appendTo(t)},string:function(o,{field:r}){e(`<span class='k-textbox k-input k-input-md k-rounded-md k-input-solid'><input tabindex='-1' id='${i()}' type='text' aria-label='${r}' title='${r}' class='k-input-inner' data-${t.ns}bind='value: value'/></span>`).appendTo(o)},boolean:function(t,{field:o}){e(`<input tabindex='-1' id='${i()}' class='k-checkbox k-checkbox-md k-rounded-md' aria-label='${o}' data-${r}role='checkbox' data-${r}bind='checked: value' type='checkbox'>`).appendTo(t)},date:function(t,{field:o}){e(`<input tabindex='-1' id='${i()}' type='text' aria-label='${o}' title='${o}' data-${r}role='datepicker' data-${r}bind='value: value'/>`).appendTo(t)}},b=a.extend({init:function(e,t){a.fn.init.call(this,e,t)},options:{name:"FilterButtonGroup"},value:function(e){if(void 0===e)return this._value;this._value=e,a.fn._select.call(this,this.wrapper.find("[value='"+e+"']")),this.trigger(d)},_select:function(t){-1!==t&&this.value(e(t).attr("value"))}}),g=l.extend({init:function(t,o){var i,r=this;l.fn.init.call(r,t,o),r.element=e(t).addClass("k-filter"),r.dataSource=o.dataSource,r.operators=e.extend(r.options.operators,o.operators),r._getFieldsInfo(),r._modelChangeHandler=r._modelChange.bind(r),r._renderMain(),o.expression&&r._addExpressionTree(r.filterModel),r._renderApplyButton(),r.options.expressionPreview&&(r._previewContainer||(r._previewContainer=e('<div class="k-filter-preview"></div>').insertAfter(r.element.children().eq(0))),i=r._createPreview(r.filterModel.toJSON()),r._previewContainer.html(i)),r._attachEvents(),r.hasCustomOperators();var s=e(r.element).find(".k-filter-toolbar > .k-toolbar");s.attr(p,-1),s.find(n).attr(p,-1),s.eq(0).attr(p,0)},events:[d],options:{name:"Filter",dataSource:null,expression:null,applyButton:!1,fields:[],mainLogic:"and",messages:{and:"And",or:"Or",apply:"Apply",close:"Close",addExpression:"Add Expression",fields:"Fields",filterExpressionLabel:"filter expression",filterLogicLabel:"filter logic",filterAriaLabel:"filter component",mainFilterLogicLabel:"main filter logic",operators:"Operators",addGroup:"Add Group"},operators:{string:{eq:u,neq:c,startswith:"Starts with",contains:"Contains",doesnotcontain:"Does not contain",endswith:"Ends with",isnull:"Is null",isnotnull:"Is not null",isempty:"Is empty",isnotempty:"Is not empty",isnullorempty:"Has no value",isnotnullorempty:"Has value"},number:{eq:u,neq:c,gte:"Is greater than or equal to",gt:"Is greater than",lte:"Is less than or equal to",lt:"Is less than",isnull:"Is null",isnotnull:"Is not null"},date:{eq:u,neq:c,gte:"Is after or equal to",gt:"Is after",lte:"Is before or equal to",lt:"Is before",isnull:"Is null",isnotnull:"Is not null"},boolean:{eq:u,neq:c}}},applyFilter:function(){var e=this.filterModel.toJSON();this._hasCustomOperators&&this._mapOperators(e),this._hasFieldsFilter(e.filters||[])?(this._removeEmptyGroups(e.filters),this.dataSource.filter(e)):this.dataSource.filter({})},destroy:function(){this.element.off(f),t.destroy(this.element.find(".k-filter-group-main")),this._previewContainer=null,this._applyButton=null,this._modelChangeHandler=null,l.fn.destroy.call(this)},setOptions:function(e){t.deepExtend(this.options,e),this.destroy(),this.element.empty(),this.init(this.element,this.options)},getOptions:function(){var t=e.extend(!0,{},this.options);return delete t.dataSource,t.expression=this.filterModel.toJSON(),t},_addExpressionTree:function(e){if(e.filters)for(var t=this.element.find("[id="+e.uid+"]"),o=0;o<e.filters.length;o++)e.filters[o].logic?this._addGroup(t,e.filters[o]):this._addExpression(t,e.filters[o]),e.filters[o].filters&&this._addExpressionTree(e.filters[o])},_click:function(t){var o=this;t.preventDefault();var i=e(t.currentTarget),r=i.data("command");"x"==r?o._removeExpression(i.closest(".k-toolbar")):"expression"==r?o._addExpression(i.closest(".k-toolbar")):"group"==r?o._addGroup(i.closest(".k-toolbar")):"apply"==r&&o.applyFilter()},_keydown:function(t){var o=this,i=e(t.target),r=t.keyCode,l=i.closest(".k-toolbar"),a=i.is(".k-toolbar");if(r===s.UP&&a)t.preventDefault(),o._focusToolbar(l,"prev");else if(r==s.DOWN&&a)t.preventDefault(),o._focusToolbar(l,"next");else if(r==s.ESC)t.stopPropagation(),o._focusToolbar(l);else if(r==s.ENTER&&a){l.find(".k-toolbar-item").eq(0).attr(p,0).trigger("focus")}},_attachEvents:function(){var e=this,t=e._click.bind(e),o=e._keydown.bind(e);e.element.on("click"+f,"button.k-button",t).on("keydown"+f,".k-filter-toolbar > .k-toolbar, .k-filter-toolbar > .k-toolbar .k-toolbar-item",o)},_focusToolbar:function(t,o,i){var r=t,s=e(this.element).find(".k-filter-toolbar > .k-toolbar");if(s.attr(p,-1),s.find(n).attr(p,-1),"next"==o){let e=Math.min(s.length-1,i||s.index(t)+1);r=s.eq(e)}else if("prev"==o){let e=Math.max(0,i||s.index(t)-1);r=s.eq(e)}r.attr(p,0).trigger("focus")},_addExpression:function(o,i){var s,l=this,a=o.attr("id"),n=o.closest(".k-filter-toolbar").next("ul.k-filter-lines"),d=i?l._fields[i.field]:l._defaultField,p="";i?s=i:((s=v(l.filterModel,a)).filters||s.set("filters",[]),s=l._addNewModel(s.filters,d)),n.length||(n=e("<ul class='k-filter-lines' role='group'></ul>").appendTo(o.closest("li")));var f={fields:l._fields,operators:l.operators[d.type],close:l.options.messages.close,fieldsLabel:l.options.messages.fields,uid:s.uid,ns:t.ns,filterExpressionLabel:l.options.messages.filterExpressionLabel},u=(p=e(t.template(expressionItemTemplate)(f)).appendTo(n)).find(".k-toolbar").first(),c=d.operators&&d.operators[d.type]?d.operators[d.type]:this.operators[d.type];u.kendoToolBar({resizable:!1,items:[{type:"component",component:"DropDownList",element:`<select data-${r}bind="value: field" title='${l.options.messages.fields}' aria-label='${l.options.messages.fields}' data-auto-width='true'></select>`,attributes:{class:"k-filter-field"},componentOptions:{title:l.options.messages.fields,dataTextField:"text",dataValueField:"value",dataSource:Object.keys(l._fields||{}).map((e=>({value:l._fields[e].name,text:l._fields[e].label})))}},{type:"component",component:"DropDownList",element:`<select data-${r}bind="value: operator" aria-label='${l.options.messages.operators}' title='${l.options.messages.operators}'></select>`,attributes:{class:"k-filter-operator"},componentOptions:{title:l.options.messages.operators,dataTextField:"text",dataValueField:"value",dataSource:Object.keys(c||{}).map((e=>({value:e,text:c.text||c[e]})))}},{attributes:{class:"k-filter-value"},template:" "},{type:"button",icon:"x",fillMode:"flat",attributes:{"data-command":"x",title:f.close,"aria-label":f.close}}]}),l._addExpressionControls(p.find(".k-toolbar"),d,s),i||l._expressionChange()},_addExpressionControls:function(e,o,i){var r=e.find(".k-toolbar-item.k-filter-operator"),s=e.find(".k-toolbar-item.k-filter-value");s.addClass("k-toolbar-tool"),t.destroy(s),s.empty(),this._bindOperators(r,o),this._appendEditor(s,o),this._bindModel(e,i),this._showHideEditor(e,i),e.find(n).attr(p,-1)},_bindOperators:function(e,t){var o=t.operators&&t.operators[t.type]?t.operators[t.type]:this.operators[t.type],i=e.find("select[data-role=dropdownlist]").getKendoDropDownList();i&&i.setDataSource(Object.keys(o||{}).map((e=>({value:e,text:o.text||o[e]}))))},_appendEditor:function(o,i){t.isFunction(i.editor)?i.editor(o,e.extend(!0,{},{field:i.name})):e(t.template(i.editor)({ns:t.ns,field:i.name,id:t.guid()})).appendTo(o)},_addNewModel:function(e,t){var o,i,r=t.type,s=t.operators;return s||(s=this.options.operators),i=Object.keys(s[r])[0],e.push({field:t.name}),(o=e[e.length-1]).set("value",t.defaultValue),o.set("operator",i),o},_addGroup:function(o,i){var r=this,s=r.filterModel,l=o.attr("id"),a=o.closest(".k-filter-toolbar").next("ul.k-filter-lines");i?s=i:((s=v(s,l)).filters||s.set("filters",[]),s.filters.push({logic:r.options.mainLogic}),s=s.filters[s.filters.length-1]),a.length||(a=e("<ul class='k-filter-lines' role='group'></ul>").appendTo(o.closest("li")));var n={operators:{and:r.options.messages.and,or:r.options.messages.or},addExpression:r.options.messages.addExpression,addGroup:r.options.messages.addGroup,close:r.options.messages.close,ns:t.ns,filterLogicLabel:r.options.messages.filterLogicLabel},d=e(t.template(logicItemTemplate)(n)).appendTo(a).find(".k-toolbar");r._initGroupToolBar(d,n),r._bindModel(d,s),i||r._expressionChange()},_bindModel:function(e,o){e.attr("id",o.uid),o.bind("change",this._modelChangeHandler),t.bind(e,o),e.parent().attr(t.attr("stop"),!0)},_createPreview:function(e){var o,i,r="",s=!1,l=this._hasFieldsFilter(e.filters||[]),a="";if(!e.filters||!e.filters.length||!l)return"";r+='<span class="k-filter-preview-bracket">(</span>';for(var n=0;n<e.filters.length;n++)(o=e.filters[n]).filters&&((a=this._createPreview(o))&&(s&&(r+='<span class="k-filter-preview-operator"> '+e.logic.toLocaleUpperCase()+" </span>"),s=!0),r+=a),o.field&&(i=this._fields[o.field],s&&(r+='<span class="k-filter-preview-operator"> '+e.logic.toLocaleUpperCase()+" </span>"),s=!0,r+='<span class="k-filter-preview-field">'+i.label+"</span>",r+='<span class="k-filter-preview-criteria"> '+this._getOperatorText(o.field,o.operator),o.operator.indexOf("is")<0?(r+=" </span>",r+="<span class='k-filter-preview-value'>'"+t.htmlEncode(i.previewFormat?t.toString(o.value,i.previewFormat):o.value)+"'</span>"):r+="</span>");return r+='<span class="k-filter-preview-bracket">)</span>'},_expressionChange:function(){var e=this,t=e.filterModel.toJSON(),o="";e.options.expressionPreview&&(o=e._createPreview(t),e._previewContainer.html(o)),e.trigger(d,{expression:t})},_getOperatorText:function(e,t){var o=this._fields[e].type,i=this._fields[e].operators;return i||(i=this.options.operators),i[o][t].text||i[o][t]},_addField:function(t,o){var i=this;t=e.extend(!0,{},{name:t.name||o,editor:t.editorTemplate||m[t.type||"string"],defaultValue:t.defaultValue||!1===t.defaultValue||0===t.defaultValue?t.defaultValue:defaultValues[t.type||"string"],type:t.type||"string",label:t.label||t.name||o,operators:t.operators,previewFormat:t.previewFormat}),i._fields[t.name]=t,i._defaultField||(i._defaultField=t)},_getFieldsInfo:function(){var e,t=this,o=t.options.fields.length?t.options.fields:(t.options.dataSource.options.schema.model||{}).fields;if(t._fields={},Array.isArray(o))for(var i=0;i<o.length;i++)e=o[i],t._addField(e);else for(var r in o)e=o[r],t._addField(e,r)},_hasFieldsFilter:function(e,t){t=!!t;for(var o=0;o<e.length;o++)if(e[o].filters&&(t=this._hasFieldsFilter(e[o].filters,t)),e[o].field)return!0;return t},_removeEmptyGroups:function(e){if(e)for(var t=e.length-1;t>=0;t--)e[t].logic&&!e[t].filters||e[t].filters&&!this._hasFieldsFilter(e[t].filters)?e.splice(t,1):e[t].filters&&this._removeEmptyGroups(e[t].filters)},_modelChange:function(e){var t=this,o=t.element.find("[id="+e.sender.uid+"]");if(t._showHideEditor(o,e.sender),"field"===e.field){var i=e.sender.field,r=e.sender.parent(),s=t._fields[i],l=t._addNewModel(r,s);e.sender.unbind("change",t._modelChangeHandler),r.remove(e.sender),t._addExpressionControls(o,s,l),t._expressionChange()}else"filters"!==e.field&&t._expressionChange()},_renderMain:function(){var o=this;e(mainContainer(o.options.messages.filterAriaLabel)).appendTo(o.element),o.options.expression?o.filterModel=t.observable(o.options.expression):o.filterModel=t.observable({logic:o.options.mainLogic});var i={operators:{and:o.options.messages.and,or:o.options.messages.or},addExpression:o.options.messages.addExpression,addGroup:o.options.messages.addGroup,close:o.options.messages.close,uid:o.filterModel.uid,ns:t.ns,mainFilterLogicLabel:o.options.messages.mainFilterLogicLabel},r=e(t.template(mainLogicTemplate)(i));r.appendTo(o.element.find("li").first());var s=r.find(".k-toolbar").first();o._initGroupToolBar(s,i),o._bindModel(s,o.filterModel)},_initGroupToolBar:function(t,o){let i=this;t.kendoToolBar({resizable:!1,toggle:function(t){i.filterModel.set("logic",e(t.target).text().toLowerCase())},items:[{type:"buttonGroup",selection:"single",buttons:[{text:i.options.messages.and,group:"mainlogic",togglable:!0,selected:"and"===i.filterModel.get("logic")},{text:i.options.messages.or,group:"mainlogic",togglable:!0,selected:"or"===i.filterModel.get("logic")}]},{type:"button",icon:"filter-add-expression",attributes:{"data-command":"expression",title:o.addExpression,"aria-label":o.addExpression}},{type:"button",icon:"filter-add-group",attributes:{"data-command":"group",title:o.addGroup,"aria-label":o.addGroup}},{type:"button",icon:"x",fillMode:"flat",attributes:{"data-command":"x",title:o.close,"aria-label":o.close}}]})},_removeExpression:function(o){var i,r,s=this,l=o.attr("id"),a=o.closest("li"),n=-1;if(a.hasClass("k-filter-group-main"))a=a.find(".k-filter-lines"),s.filterModel.filters&&(s.filterModel.filters.empty(),delete s.filterModel.filters);else{n=e(s.element).find(".k-filter-toolbar > .k-toolbar").index(o),i=(r=v(s.filterModel,l)).parent(),r.unbind("change",s._modelChangeHandler),i.remove(r),i.length||delete i.parent().filters,a.siblings().length||(a=a.parent())}t.destroy(a),a.remove(),s._expressionChange(),n>-1&&s._focusToolbar(o,"next",n)},_renderApplyButton:function(){var o=this;o.options.applyButton&&(o._applyButton||(o._applyButton=e(t.format('<button type="button" data-command="apply" aria-label="{0}" title="{0}" class="k-button k-button-md k-rounded-md k-button-solid k-button-solid-base k-filter-apply"><span class="k-button-text">{0}</span></button>',o.options.messages.apply)).appendTo(o.element)))},_showHideEditor:function(e,t){if(!t.logic){var o=t.operator,i=e.find(".k-toolbar-item.k-filter-value");"isnull"==o||"isnotnull"==o||"isempty"==o||"isnotempty"==o||"isnullorempty"==o||"isnotnullorempty"==o?i.hide():i.show()}},_mapOperators:function(e){var t=this;e.filters&&e.filters.forEach((function(e){if(e.filters)t._mapOperators(e);else{var o,i=t._fields[e.field],r=i.type;(o=i.operators&&i.operators[r][e.operator]?i.operators[r][e.operator]:t.operators[r][e.operator])&&(e.operator=o.handler||e.operator)}}))},hasCustomOperators:function(){var t=e.extend(!0,{},this.operators);for(var o in this._fields)t=e.extend(!0,{},t,this._fields[o].operators);this._hasCustomOperators=h(t)}});function h(e){for(var t in e){var o=e[t];if(o.handler&&"function"==typeof o.handler||"object"==typeof o&&null!==o&&h(o))return!0}return!1}function v(e,t){if(e.uid===t)return e;if(e.filters)for(var o=0;o<e.filters.length;o++){var i=v(e.filters[o],t);if(i)return i}}o.plugin(g),o.plugin(b)}(window.kendo.jQuery);var kendo$1=kendo;export{kendo$1 as default};
//# sourceMappingURL=kendo.filter.js.map
