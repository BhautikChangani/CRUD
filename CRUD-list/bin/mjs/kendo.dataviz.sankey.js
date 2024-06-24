/**
 * Kendo UI v2024.2.514 (http://www.telerik.com/kendo-ui)
 * Copyright 2024 Progress Software Corporation and/or one of its subsidiaries or affiliates. All rights reserved.
 *
 * Kendo UI commercial licenses may be obtained at
 * http://www.telerik.com/purchase/license-agreement/kendo-ui-complete
 * If you do not own a commercial license, this file shall be governed by the trial license terms.
 */
import"./kendo.core.js";import"./kendo.color.js";import"./kendo.drawing.js";import"./kendo.dataviz.core.js";import"./kendo.dataviz.chart.js";!function(t){window.kendo.dataviz=window.kendo.dataviz||{};var e=kendo.dataviz,i=e.deepExtend,o=e.Box,n=e.setDefaultOptions,r=e.constants,s=kendo.geometry,a=kendo.drawing,l=e.Legend,h=function(t,e){return t.map(e).reduce((function(t,e){return t+e}),0)},c=function(t,e){return t.y0===e.y0?t.index-e.index:t.y0+t.y1-e.y0-e.y1},u=function(t,e){return c(t.source,e.source)},p=function(t,e){return c(t.target,e.target)},d=function(t){return t.value};function f(t){t.forEach((function(t){t.targetLinks.forEach((function(t){t.source.sourceLinks.sort(p)})),t.sourceLinks.forEach((function(t){t.target.targetLinks.sort(u)}))}))}var g=function(t,e){return"left"===t.align?t.depth:"right"===t.align?e-t.height:t.sourceLinks.length?t.depth:e},y=kendo.Class.extend({init:function(t){var e=t.nodesOptions,o=e.offset;void 0===o&&(o={});var n=e.align;this.data={nodes:t.nodes.map((function(t){return i({},{offset:o,align:n},t)})),links:t.links.map((function(t){return i({},t)}))},this.width=t.width,this.height=t.height,this.offsetX=t.offsetX||0,this.offsetY=t.offsetY||0,this.nodeWidth=t.nodesOptions.width,this.nodePadding=t.nodesOptions.padding,this.reverse=t.reverse,this.targetColumnIndex=t.targetColumnIndex,this.loops=t.loops,this.autoLayout=t.autoLayout},calculate:function(){var e=this.data,i=e.nodes,o=e.links;this.connectLinksToNodes(i,o),this.calculateNodeValues(i);var n=this.calculateNodeHeights(i);if(n)return{nodes:[],links:[],columns:[],circularLinks:n};this.calculateNodeDepths(i);var r=this.calculateNodeColumns(i);return this.calculateNodeBreadths(r),this.applyNodesOffset(i),this.calculateLinkBreadths(i),t.extend({},this.data,{columns:r})},connectLinksToNodes:function(t,e){var i=new Map;t.forEach((function(t,e){t.index=e,t.sourceLinks=[],t.targetLinks=[],t.id=void 0!==t.id?t.id:t.label.text,i.set(t.id,t)})),e.forEach((function(t){t.source=i.get(t.sourceId),t.target=i.get(t.targetId),t.source.sourceLinks.push(t),t.target.targetLinks.push(t)}))},calculateNodeValues:function(t){t.forEach((function(t){t.value=Math.max(h(t.sourceLinks,d),h(t.targetLinks,d))}))},calculateNodeDepths:function(t){for(var e=new Set(t),i=new Set,o=0;e.size;){for(var n=Array.from(e),r=0;r<n.length;r++){var s=n[r];s.depth=o;for(var a=0;a<s.sourceLinks.length;a++){var l=s.sourceLinks[a];i.add(l.target)}}o++,e=i,i=new Set}},calculateNodeHeights:function(t){for(var e=t.length,i=new Set(t),o=new Set,n=0,r=function(t){t.height=n,t.targetLinks.forEach((function(t){o.add(t.source)}))};i.size;){if(i.forEach(r),++n>e)return!0;i=o,o=new Set}return!1},calculateNodeColumns:function(t){for(var e,i,o=(e=t,i=function(t){return t.depth},Math.max.apply(null,e.map(i))),n=(this.width-this.offsetX-this.nodeWidth)/o,r=new Array(o+1),s=0;s<t.length;s++){var a=t[s],l=Math.max(0,Math.min(o,g(a,o)));a.x0=this.offsetX+l*n,a.x1=a.x0+this.nodeWidth,a.layer=l,r[l]=r[l]||[],r[l].push(a)}return r},calculateNodeBreadths:function(t){var e,i,o=this,n=(e=t,i=function(t){return(o.height-o.offsetY-(t.length-1)*o.nodePadding)/h(t,d)},Math.min.apply(null,e.map(i)));if(t.forEach((function(t){var e=o.offsetY;t.forEach((function(t){t.y0=e,t.y1=e+t.value*n,e=t.y1+o.nodePadding,t.sourceLinks.forEach((function(t){t.width=t.value*n}))})),e=(o.height-e+o.nodePadding)/(t.length+1),t.forEach((function(t,i){t.y0+=e*(i+1),t.y1+=e*(i+1)}))})),!1!==this.autoLayout)for(var r=void 0!==this.loops?this.loops:t.length-1,s=this.targetColumnIndex||1,a=0;a<r;a++)o.reverse?(o.uncurlLinksToRight(t,s),o.uncurlLinksToLeft(t,s)):(o.uncurlLinksToLeft(t,s),o.uncurlLinksToRight(t,s));t.forEach(f)},applyNodesOffset:function(t){t.forEach((function(t){var e=(t.offset?t.offset.left:0)||0,i=(t.offset?t.offset.top:0)||0;t.x0+=e,t.x1+=e,t.y0+=i,t.y1+=i}))},calculateLinkBreadths:function(t){t.forEach((function(t){var e=t.sourceLinks,i=t.targetLinks,o=t.y0,n=o;e.forEach((function(t){t.x0=t.source.x1,t.y0=o+t.width/2,o+=t.width})),i.forEach((function(t){t.x1=t.target.x0,t.y1=n+t.width/2,n+=t.width}))}))},uncurlLinksToRight:function(t,e){for(var i=this,o=t.length,n=e;n<o;n++){var r=t[n];r.forEach((function(t){var e=0,o=0;t.targetLinks.forEach((function(n){var r=n.value*(t.layer-n.source.layer);e+=i.targetTopPos(n.source,t)*r,o+=r}));var n=0===e?0:e/o-t.y0;t.y0+=n,t.y1+=n,f([t])})),r.sort(c),i.arrangeNodesVertically(r)}},uncurlLinksToLeft:function(t,e){for(var i=this,o=t.length-1-e;o>=0;o--){for(var n=t[o],r=function(t){var e=n[t],o=0,r=0;e.sourceLinks.forEach((function(t){var n=t.value*(t.target.layer-e.layer);o+=i.sourceTopPos(e,t.target)*n,r+=n}));var s=0===o?0:o/r-e.y0;e.y0+=s,e.y1+=s,f([e])},s=0;s<n.length;s++)r(s);n.sort(c),i.arrangeNodesVertically(n)}},arrangeNodesVertically:function(t){var e=t.length-1;this.arrangeUp(t,this.height,e),this.arrangeDown(t,this.offsetY,0)},arrangeDown:function(t,e,i){for(var o=e,n=i;n<t.length;n++){var r=t[n],s=Math.max(0,o-r.y0);r.y0+=s,r.y1+=s,o=r.y1+this.nodePadding}},arrangeUp:function(t,e,i){for(var o=e,n=i;n>=0;--n){var r=t[n],s=Math.max(0,r.y1-o);r.y0-=s,r.y1-=s,o=r.y0-this.nodePadding}},sourceTopPos:function(t,e){for(var i=e.y0-(e.targetLinks.length-1)*this.nodePadding/2,o=0;o<e.targetLinks.length;o++){var n=e.targetLinks[o];if(n.source===t)break;i+=n.width+this.nodePadding}for(var r=0;r<t.sourceLinks.length;r++){var s=t.sourceLinks[r];if(s.target===e)break;i-=s.width}return i},targetTopPos:function(t,e){for(var i=t.y0-(t.sourceLinks.length-1)*this.nodePadding/2,o=0;o<t.sourceLinks.length;o++){var n=t.sourceLinks[o];if(n.target===e)break;i+=n.width+this.nodePadding}for(var r=0;r<e.targetLinks.length;r++){var s=e.targetLinks[r];if(s.source===t)break;i-=s.width}return i}}),v=function(t){return new y(t).calculate()};function m(t,e,i,o,n,r){var s=(r-e)*(i-t),a=(o-e)*(n-t);return s>a?1:s===a?0:-1}var k=function(t){function e(e){t.call(this),this.options=i({},this.options,e),this.createVisual()}return t&&(e.__proto__=t),e.prototype=Object.create(t&&t.prototype),e.prototype.constructor=e,e.prototype.createVisual=function(){this.visual=this.createElement()},e.prototype.exportVisual=function(){return this.visual},e.prototype.createElement=function(){var t=this,e=this.options.visual;return e?e({sender:this.getSender(),options:this.visualOptions(),createVisual:function(){return t.getElement()}}):this.getElement()},e.prototype.getSender=function(){return this},e}(e.Class),w=function(t){function e(){t.apply(this,arguments)}return t&&(e.__proto__=t),e.prototype=Object.create(t&&t.prototype),e.prototype.constructor=e,e.prototype.getElement=function(){var t=this.options.node,e=new s.Rect([t.x0,t.y0],[t.x1-t.x0,t.y1-t.y0]);return a.Path.fromRect(e,this.visualOptions())},e.prototype.visualOptions=function(){var t=i({},this.options,this.options.node);return{fill:{color:t.color,opacity:t.opacity},stroke:{width:0},className:"k-sankey-node",role:"graphics-symbol",ariaRoleDescription:"Node",ariaLabel:t.node.label.text}},e}(k),x=function(t,e,i){return t.color||e[i%e.length]},_=function(t,e,o,n){var r=i({},e,e.node);return i({},{color:x(t,o,n)},r,{node:t},{visual:t.visual,opacity:t.opacity,offset:t.offset,color:t.color})},b=a.util.defined,E=function(t){function e(){t.apply(this,arguments)}return t&&(e.__proto__=t),e.prototype=Object.create(t&&t.prototype),e.prototype.constructor=e,e.prototype.getElement=function(){var t=this.options.link,e=t.x0,i=t.x1,o=t.y0,n=t.y1,r=(e+i)/2;return new a.Path(this.visualOptions()).moveTo(e,o).curveTo([r,o],[r,n],[i,n])},e.prototype.visualOptions=function(){var t=this.options,e=this.options.link;return{stroke:{width:t.link.width,color:e.color||t.color,opacity:b(e.opacity)?e.opacity:t.opacity}}},e}(k),O="inside",L="before",T=function(t){function n(){t.apply(this,arguments)}return t&&(n.__proto__=t),n.prototype=Object.create(t&&t.prototype),n.prototype.constructor=n,n.prototype.getElement=function(){var t=i({},this.options,this.options.node.label),n=t.node,r=t.totalWidth,s=t.position,a=t.text,l=t.offset;if(!t.visible||!a)return null;var h=new o(n.x0,n.y0,n.x1,n.y1),c=this.visualOptions(),u=new e.TextBox(a,c);u.reflow(new o);var p=u.box,d=n.x1+p.width()>r,f=h.center().y-p.height()/2,g=[(s===L||s===O&&d?L:"after")===L?n.x0-p.width():n.x1,f],y=new o(g[0],g[1],g[0]+p.width(),g[1]+p.height());return y.translate(l.left||0,l.top||0),u.reflow(y),u.renderVisual(),u.visual},n.prototype.visualOptions=function(){var t=i({},this.options,this.options.node.label);return{color:t.color,font:t.font,border:t.border,margin:t.margin,padding:t.padding,align:t.align,paintOrder:t.paintOrder,stroke:t.stroke}},n}(k);n(T,{position:O});var S=function(t,e,o){return i({},e,{node:t,totalWidth:o,visual:t.label.visual,visible:t.label.visible,margin:t.label.margin,padding:t.label.padding,border:t.label.border,align:t.label.align,offset:t.label.offset})},z=function(t){function i(){t.apply(this,arguments)}return t&&(i.__proto__=t),i.prototype=Object.create(t&&t.prototype),i.prototype.constructor=i,i.prototype.getElement=function(){var t=this.options,i=t.drawingRect,o=t.text;if(!1===t.visible||!o)return null;var n=e.Title.buildTitle(o,t);return n.reflow(i),n.renderVisual(),n.visual},i.prototype.createElement=function(){return this.getElement()},i}(k);n(z,{align:r.CENTER,border:{width:0},margin:e.getSpacing(5),padding:e.getSpacing(5)});var I=function(t,e){return t.node.x0-e.node.x0!=0?t.node.x0-e.node.x0:t.node.y0-e.node.y0},V=function(e){function i(){e.apply(this,arguments)}return e&&(i.__proto__=e),i.prototype=Object.create(e&&e.prototype),i.prototype.constructor=i,i.prototype.getElement=function(){var e=this.options,i=e.drawingRect,o=e.nodes;void 0===o&&(o=[]);var n=e.item;if(!1===e.visible||!o.length)return null;var r=o.map((function(t){return{text:t.label&&t.label.text||"",area:{background:void 0!==n.areaBackground?n.areaBackground:t.color,opacity:void 0!==n.areaOpacity?n.areaOpacity:t.opacity},node:t}}));r.sort(I);var s=new l(t.extend({},e,{data:r}));return s.reflow(i),s.renderVisual(),s.visual},i.prototype.createElement=function(){return this.getElement()},i}(k);n(V,{markers:{visible:!1},item:{type:"area",cursor:r.POINTER,opacity:1},position:r.BOTTOM,align:r.CENTER,border:{width:0}});var B="link",C="node",P=function(n){function l(t,e,i){n.call(this),this._initTheme(i),this._setOptions(e),this._initElement(t),this._initSurface(),e&&e.data&&(this._redraw(),this._initResizeObserver())}return n&&(l.__proto__=n),l.prototype=Object.create(n&&n.prototype),l.prototype.constructor=l,l.prototype.destroy=function(){this.unbind(),this._destroySurface(),this._destroyResizeObserver()},l.prototype._initElement=function(t){this.element=t,e.addClass(t,["k-chart","k-sankey"]),t.setAttribute("role","graphics-document"),t.tabIndex=t.getAttribute("tabindex")||0;var i=this.options.title;i.text&&t.setAttribute("aria-label",i.text),i.description&&t.setAttribute("aria-roledescription",i.description)},l.prototype._initSurface=function(){this.surface||(this._destroySurface(),this._initSurfaceElement(),this.surface=this._createSurface())},l.prototype._initResizeObserver=function(){var t=this,e=new ResizeObserver((function(e){e.forEach((function(e){var i=e.contentRect,o=i.width,n=i.height;e.target!==t.element||t.size&&t.size.width===o&&t.size.height===n||(t.size={width:o,height:n},t.surface.setSize(t.size),t.resize=!0,t._redraw())}))}));this._resizeObserver=e,e.observe(this.element)},l.prototype._createSurface=function(){return a.Surface.create(this.surfaceElement,{mouseenter:this._mouseenter.bind(this),mouseleave:this._mouseleave.bind(this),mousemove:this._mousemove.bind(this),click:this._click.bind(this)})},l.prototype._initTheme=function(t){var e=t||this.theme||{};this.theme=e,this.options=i({},e,this.options)},l.prototype.setLinksOpacity=function(t){var e=this;this.linksVisuals.forEach((function(i){e.setOpacity(i,t,i.linkOptions.opacity)}))},l.prototype.setLinksInactivityOpacity=function(t){var e=this;this.linksVisuals.forEach((function(i){e.setOpacity(i,t,i.linkOptions.highlight.inactiveOpacity)}))},l.prototype.setOpacity=function(e,i,o){e.options.set("stroke",t.extend({},e.options.stroke,{opacity:b(o)?o:i}))},l.prototype.trigger=function(e,i){var o=t.extend({},i,{type:e,targetType:i.element.type,dataItem:i.element.dataItem});return n.prototype.trigger.call(this,e,o)},l.prototype._mouseenter=function(t){var e=t.element,i=e.type===B,o=e.type===C,n=Boolean(e.chartElement&&e.chartElement.options.node);if(!(i&&this.trigger("linkEnter",t)||o&&this.trigger("nodeEnter",t))){var r=this.options.links.highlight;if(i)this.setLinksInactivityOpacity(r.inactiveOpacity),this.setOpacity(e,r.opacity,e.linkOptions.highlight.opacity);else if(o)this.highlightLinks(e,r);else if(n){var s=this.nodesVisuals.get(e.chartElement.options.node.id);this.highlightLinks(s,r)}}},l.prototype._mouseleave=function(t){var e=this,i=t.element,o=i.type===B,n=i.type===C,r=Boolean(i.chartElement&&i.chartElement.options.node),s=t.originalEvent.relatedTarget;o&&s&&"text"===s.nodeName||((o||n)&&(this.tooltipTimeOut&&(clearTimeout(this.tooltipTimeOut),this.tooltipTimeOut=null),this.tooltipShown=!1,this.trigger("tooltipHide",t)),o&&this.trigger("linkLeave",t)||n&&this.trigger("nodeLeave",t)||(o||n||r)&&this.linksVisuals.forEach((function(t){e.setOpacity(t,e.options.links.opacity,t.linkOptions.opacity)})))},l.prototype._mousemove=function(t){var e=this,i=this.options.tooltip,o=i.followPointer,n=i.delay,r=t.element,s=r.type;if(!(s!==B&&s!==C||this.tooltipShown&&!o)){var a=t.originalEvent,l=this.element.getBoundingClientRect(),h=a.clientX-l.left<l.width/2,c=a.clientY-l.top<l.height/2;if(t.tooltipData={popupOffset:{left:a.pageX,top:a.pageY},popupAlign:{horizontal:h?"left":"right",vertical:c?"top":"bottom"}},s===C){var u=r.dataItem,p=u.sourceLinks,d=u.targetLinks,f=d.length?d:p;t.nodeValue=f.reduce((function(t,e){return t+e.value}),0)}this.tooltipTimeOut&&(clearTimeout(this.tooltipTimeOut),this.tooltipTimeOut=null);var g=o&&this.tooltipShown?0:n;this.tooltipTimeOut=setTimeout((function(){e.trigger("tooltipShow",t),e.tooltipShown=!0,e.tooltipTimeOut=null}),g)}},l.prototype._click=function(t){var e=t.element,i=e.type===B;e.type===C?this.trigger("nodeClick",t):i&&this.trigger("linkClick",t)},l.prototype.highlightLinks=function(t,e){var i=this;t&&(this.setLinksInactivityOpacity(e.inactiveOpacity),t.links.forEach((function(t){i.setOpacity(t,e.opacity,t.linkOptions.highlight.opacity)})))},l.prototype._destroySurface=function(){this.surface&&(this.surface.destroy(),this.surface=null,this._destroySurfaceElement())},l.prototype._destroyResizeObserver=function(){this._resizeObserver&&(this._resizeObserver.disconnect(),this._resizeObserver=null)},l.prototype._initSurfaceElement=function(){this.surfaceElement||(this.surfaceElement=document.createElement("div"),this.element.appendChild(this.surfaceElement))},l.prototype._destroySurfaceElement=function(){this.surfaceElement&&this.surfaceElement.parentNode&&(this.surfaceElement.parentNode.removeChild(this.surfaceElement),this.surfaceElement=null)},l.prototype.setOptions=function(t,e){this._setOptions(t),this._initTheme(e),this._initSurface(),this._redraw()},l.prototype._redraw=function(){this.surface.clear();var t=this._getSize(),e=t.width,i=t.height;this.size={width:e,height:i},this.surface.setSize(this.size),this.createVisual(),this.surface.draw(this.visual)},l.prototype._getSize=function(){return this.element.getBoundingClientRect()},l.prototype.createVisual=function(){this.visual=this._render()},l.prototype.titleBox=function(e,i){return e&&!1!==e.visible&&e.text?new z(t.extend({},{drawingRect:i},e)).exportVisual().chartElement.box:null},l.prototype.legendBox=function(e,i,o){return e&&!1!==e.visible?new V(t.extend({},{nodes:i},e,{drawingRect:o})).exportVisual().chartElement.box:null},l.prototype.calculateSankey=function(i,n){var s=n.title,a=n.legend,l=n.data,h=n.nodes,c=n.labels,u=n.nodeColors,p=!n.disableAutoLayout,d=new o(0,0,i.width,i.height),f=this.titleBox(s,d),g=d.clone();if(f){var y=f.height();s.position===r.TOP?(d.unpad({top:y}),g=new o(0,y,i.width,i.height)):(d.shrink(0,y),g=new o(0,0,i.width,i.height-y))}var k=this.legendBox(a,l.nodes,g),x=a&&a.position||V.prototype.options.position;k&&(x===r.LEFT&&d.unpad({left:k.width()}),x===r.RIGHT&&d.shrink(k.width(),0),x===r.TOP&&d.unpad({top:k.height()}),x===r.BOTTOM&&d.shrink(0,k.height()));var b=v(t.extend({},i,{offsetX:0,offsetY:0,width:d.width(),height:d.height()})),E=b.nodes,O=b.circularLinks;if(O)return console.warn("Circular links detected. Kendo Sankey diagram does not support circular links."),{sankey:{nodes:[],links:[],circularLinks:O},legendBox:k,titleBox:f};var L=new o;E.forEach((function(t,i){var o=_(t,h,u,i),n=new w(o);L.wrap(e.rectToBox(n.exportVisual().rawBBox()));var r=new T(S(t,c,d.width())).exportVisual();r&&L.wrap(e.rectToBox(r.rawBBox()))}));var z=d.x1,I=d.y1,B=d.width()+z,C=d.height()+I;if(B-=L.x2>d.width()?L.x2-d.width():0,C-=L.y2>d.height()?L.y2-d.height():0,z+=L.x1<0?-L.x1:0,I+=L.y1<0?-L.y1:0,!1===p)return{sankey:v(t.extend({},i,{offsetX:z,offsetY:I,width:B,height:C,autoLayout:!1})),legendBox:k,titleBox:f};if(this.resize&&p&&this.permutation)return this.resize=!1,{sankey:v(t.extend({},i,{offsetX:z,offsetY:I,width:B,height:C},this.permutation)),legendBox:k,titleBox:f};for(var P=v(t.extend({},i,{offsetX:z,offsetY:I,width:B,height:C,autoLayout:!1})).columns.length,R=[],N=function(e,o){var n=function(t){for(var e,i,o,n,r,s,a=0,l=t.length,h=0;h<l;h++)for(var c=t[h],u=h+1;u<l;u++){var p=t[u];i=p,o=void 0,n=void 0,r=void 0,s=void 0,o=m((e=c).x0,e.y0,e.x1,e.y1,i.x1,i.y1),n=m(e.x0,e.y0,e.x1,e.y1,i.x0,i.y0),r=m(e.x0,e.y0,i.x0,i.y0,i.x1,i.y1),s=m(e.x1,e.y1,i.x0,i.y0,i.x1,i.y1),o!==n&&r!==s&&(a+=Math.min(c.value,p.value))}return a}(v(t.extend({},i,{offsetX:z,offsetY:I,width:B,height:C,loops:2,targetColumnIndex:e,reverse:o})).links);return R.push({crosses:n,reverse:o,targetColumnIndex:e}),0===n},M=1;M<=P-1&&(!N(M,!1)&&!N(M,!0));M++);var $=Math.min.apply(null,R.map((function(t){return t.crosses}))),D=R.find((function(t){return t.crosses===$}));return this.permutation={targetColumnIndex:D.targetColumnIndex,reverse:D.reverse},{sankey:v(t.extend({},i,{offsetX:z,offsetY:I,width:B,height:C},this.permutation)),legendBox:k,titleBox:f}},l.prototype._render=function(e,o){var n=e||this.options,r=o||this,l=n.data,h=n.labels,c=n.nodes,u=n.links,p=n.nodeColors,d=n.title,f=n.legend,g=r.size,y=g.width,v=g.height,m=t.extend({},l,{width:y,height:v,nodesOptions:c,title:d,legend:f}),k=this.calculateSankey(m,n),x=k.sankey,b=k.titleBox,O=k.legendBox,L=x.nodes,I=x.links,P=new a.Group({clip:a.Path.fromRect(new s.Rect([0,0],[y,v]))});if(b){var R=new z(t.extend({},d,{drawingRect:b})).exportVisual();P.append(R)}if(x.circularLinks)return P;var N=new Map;r.nodesVisuals=N,L.forEach((function(e,i){var o=_(e,c,p,i),n=new w(o).exportVisual();n.links=[],n.type=C,e.color=o.color,e.opacity=o.opacity,n.dataItem=t.extend({},l.nodes[i],{color:o.color,opacity:o.opacity,sourceLinks:e.sourceLinks.map((function(t){return{sourceId:t.sourceId,targetId:t.targetId,value:t.value}})),targetLinks:e.targetLinks.map((function(t){return{sourceId:t.sourceId,targetId:t.targetId,value:t.value}}))}),N.set(e.id,n),P.append(n)}));var M=I.slice().sort((function(t,e){return e.value-t.value})),$=[];r.linksVisuals=$,M.forEach((function(e){var o=e.source,n=e.target,r=N.get(o.id),s=N.get(n.id),a=function(t,e,o,n){var r=i({},e,{link:t,opacity:t.opacity,color:t.color,colorType:t.colorType,visual:t.visual,highlight:t.highlight});return"source"===r.colorType?r.color=o.options.fill.color:"target"===r.colorType&&(r.color=n.options.fill.color),r}(e,u,r,s),l=new E(a).exportVisual();l.type=B,l.dataItem={source:t.extend({},r.dataItem),target:t.extend({},s.dataItem),value:e.value},l.linkOptions=a,$.push(l),r.links.push(l),s.links.push(l),P.append(l)}));var D=L.reduce((function(t,e){return Math.max(t,e.x1)}),0);if(L.forEach((function(t){var e=S(t,h,D),i=new T(e).exportVisual();i&&P.append(i)})),O){var j=new V(t.extend({},f,{drawingRect:O,nodes:L})).exportVisual();P.append(j)}return P},l.prototype.exportVisual=function(t){var e=t&&t.options?i({},this.options,t.options):this.options,o={size:{width:b(t&&t.width)?t.width:this.size.width,height:b(t&&t.height)?t.height:this.size.height}};return this._render(e,o)},l.prototype._setOptions=function(t){this.options=i({},this.options,t)},l}(e.Observable);n(P,{title:{position:r.TOP},labels:{visible:!0,margin:{left:8,right:8},padding:0,border:{width:0},paintOrder:"stroke",stroke:{lineJoin:"round",width:1},align:r.LEFT,offset:{left:0,top:0}},nodes:{width:24,padding:16,opacity:1,align:"stretch",offset:{left:0,top:0}},links:{colorType:"static",opacity:.4,highlight:{opacity:.8,inactiveOpacity:.2}},tooltip:{followPointer:!1,delay:200}});kendo.deepExtend(kendo.dataviz,{Sankey:P,createSankeyData:function(t,e,i){var o=new Set,n=new Map,r=new Map;t.forEach((function(t){e.forEach((function(e){o.add(e.value(t))}));for(var s=0;s<e.length-1;s++){var a=e[s].value(t),l=e[s+1].value(t),h=a+"_"+l,c=i.value(t),u=n.get(h);void 0!==u?n.set(h,u+c):(n.set(h,c),r.set(h,{source:a,target:l}))}}));var s=new Map,a=Array.from(o).map((function(t,e){return s.set(t,e),{id:e,label:{text:String(t)}}})),l=Array.from(n).map((function(t){var e=t[0],i=t[1],o=r.get(e),n=o.source,a=o.target;return{sourceId:s.get(n),targetId:s.get(a),value:i}}));return{nodes:a,links:l}}})}(window.kendo.jQuery),function(t){var e=window.kendo,i=e.ui.Widget,o=e.htmlEncode,n="__style",r=`${n}="display: flex; align-items: center;"`,s=t=>`<span ${n}="margin: 0 3px">${t}</span>`,a=t=>`<div ${n}="width: 15px; height: 15px; background-color: ${t}; display: inline-flex; margin-left: 3px"></div>`,l={node:function({dataItem:t,value:e}){const{color:i,label:n}=t;return`<div ${r}>\n                    ${a(i)}\n                    ${s(o(n.text))}\n                    ${s(e)}\n                </div>`},link:function({dataItem:t,value:i}){const{source:n,target:l}=t;return`<div ${r}>\n                    ${a(n.color)}\n                    ${s(o(n.label.text))}\n                    ${s(e.ui.icon({icon:"arrow-right"}))}\n                    ${a(l.color)}\n                    ${s(o(l.label.text))}\n                    ${s(i)}\n                </div>`}},h=i.extend({init:function(t,e){this.options=e,i.fn.init.call(this,t),this.element.addClass("k-tooltip k-chart-tooltip k-chart-shared-tooltip").append('<div class="k-tooltip-content"></div>')},size:function(){return{width:this.element.outerWidth(),height:this.element.outerHeight()}},setContent:function(t){this.element.find(".k-tooltip-content").html(t),this.element.find(`[${n}]`).each(((t,e)=>{e.getAttribute(n).split(";").filter((t=>""!==t)).forEach((t=>{const i=t.split(":");e.style[i[0].trim()]=i[1].trim()})),e.removeAttribute(n)}))},setPosition:function(t,e,i){const o=this.size(),n={...e};n.left+="left"===t.horizontal?i:-1*i,"right"===t.horizontal&&(n.left-=o.width),"bottom"===t.vertical?n.top-=o.height+i:n.top+=i,this.element.css(n)},show:function(){this.element.show()},hide:function(){this.element.hide()},destroy:function(){this.element.remove()}});e.deepExtend(e.dataviz,{SankeyTooltip:{Tooltip:h,ContentTemplates:l}})}(window.kendo.jQuery),function(t){var e=window.kendo,i=e.template,o=e.ui.Widget,n=e.dataviz,r=n.defined,s=e.htmlEncode,a=n.Sankey;const{Tooltip:l,ContentTemplates:h}=n.SankeyTooltip;var c=o.extend({init:function(i,r){e.destroy(i),t(i).empty(),this.options=e.deepExtend(this.options,r),o.fn.init.call(this,i),this.wrapper=this.element,this._initSankey(),this._attachEvents(),e.notify(this,n.ui),this._showWatermarkOverlay&&this._showWatermarkOverlay(this.wrapper[0])},setOptions:function(t){var e=this.options;this.events.forEach((t=>{e[t]&&this.unbind(t,e[t])})),this._instance.setOptions(t),this.bind(this.events,this._instance.options)},_initSankey:function(){const t=this._getThemeOptions(this.options),{seriesColors:e,axisDefaults:i,seriesDefaults:o,legend:n,title:r}=t,{line:s,labels:a}=i,l=o.labels.background;this._createSankey(this.options,{nodeColors:e,links:s,labels:{...a,stroke:{color:l}},legend:n,title:r}),this.options=this._instance.options},_createSankey:function(t,e){this._instance=new a(this.element[0],t,e)},_getThemeOptions:function(t){var e=(t||{}).theme;if(e&&-1!==n.SASS_THEMES.indexOf(e.toLowerCase()))return n.autoTheme().chart;if(r(e)){var i=n.ui.themes||{};return(i[e]||i[e.toLowerCase()]||{}).chart||{}}},_attachEvents:function(){this.events.forEach((t=>{this._instance.bind(t,(e=>{this._events[t]&&this._events[t].forEach((t=>t.call(void 0,e)))}))})),this._instance.bind("tooltipShow",this.tooltipShow.bind(this)),this._instance.bind("tooltipHide",this.tooltipHide.bind(this))},tooltipShow:function(o){if(!this._tooltip){const e=this.element[0].ownerDocument;this._tooltip=new l(e.createElement("div"),{});const{appendTo:i=e.body}=this.options.tooltip;this._tooltip.element.appendTo(t(i))}const{nodeTemplate:n,linkTemplate:a,offset:c}=this.options.tooltip,u=i(("node"===o.targetType?n:a)||h[o.targetType]),p=s(e.format(this.options.messages.tooltipUnits,r(o.nodeValue)?o.nodeValue:o.dataItem.value));this._tooltip.setContent(u({dataItem:o.dataItem,value:p})),this._tooltip.setPosition(o.tooltipData.popupAlign,o.tooltipData.popupOffset,c),this._tooltip.show()},tooltipHide:function(){this._tooltip&&(this._tooltip.destroy(),this._tooltip=null)},exportVisual:function(t){return this._instance.exportVisual(t)},destroy:function(){o.fn.destroy.call(this),this.tooltipHide(),this._instance.destroy(),this._instance=null},events:["nodeClick","linkClick","nodeEnter","nodeLeave","linkEnter","linkLeave"],options:{name:"Sankey",theme:"default",tooltip:{offset:12},messages:{tooltipUnits:"({0} Units)"}}});n.ExportMixin.extend(c.fn),e.PDFMixin&&e.PDFMixin.extend(c.fn),n.ui.plugin(c),e.deepExtend(n,{Sankey:c})}(window.kendo.jQuery);let __meta__={id:"dataviz.sankey",name:"Sankey",category:"dataviz",description:"The Sankey widget uses modern browser technologies to render high-quality data visualizations in the browser.",depends:["data","userevents","drawing","dataviz.core","dataviz.themes"],features:[{id:"dataviz.sankey-pdf-export",name:"PDF export",description:"Export Sankey as PDF",depends:["pdf"]}]};var kendo$1=kendo;export{kendo$1 as default};
//# sourceMappingURL=kendo.dataviz.sankey.js.map