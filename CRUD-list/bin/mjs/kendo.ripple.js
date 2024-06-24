/**
 * Kendo UI v2024.2.514 (http://www.telerik.com/kendo-ui)
 * Copyright 2024 Progress Software Corporation and/or one of its subsidiaries or affiliates. All rights reserved.
 *
 * Kendo UI commercial licenses may be obtained at
 * http://www.telerik.com/purchase/license-agreement/kendo-ui-complete
 * If you do not own a commercial license, this file shall be governed by the trial license terms.
 */
import"./kendo.core.js";!function(){window.kendo.util=window.kendo.util||{},window.kendo.util.ripple=window.kendo.util.ripple||{};var e=function(e,t,n){var o=function(){n(),e.removeEventListener(t,o,!1)},i=function(){return e.addEventListener(t,o,!1)};return i(),{remove:i}},t=function(t,i){return function(r){var s,a=r.target,c=a.document||a.ownerDocument;if((s=i.container?i.container(a):function(e,t){if(e.closest)return e.closest(t);for(var n=Element.prototype.matches?function(e,t){return e.matches(t)}:function(e,t){return e.msMatchesSelector(t)},o=e;o;){if(n(o,t))return o;o=o.parentElement}}(a,t))&&!(/focus/i.test(r.type)&&s.classList.contains("k-ripple-target")))if(a.classList.contains("k-checkbox")||a.classList.contains("k-radio"))r.target.classList.remove("k-ripple-focus"),"animationend"!==r.type&&r.target.classList.add("k-ripple-focus");else{s.classList.add("k-ripple-target");var l=function(e){var t=e.createElement("div");t.className="k-ripple";var n=e.createElement("div");return n.className="k-ripple-blob",t.appendChild(n),[t,n]}(c),p=l[0],u=l[1],d={animated:!1,released:!1,blob:u,container:s,ripple:p},f={focusin:"focusout",keydown:"keyup",mousedown:"mouseup",pointerdown:"pointerup",touchdown:"touchup",animationstart:"animationend"}[r.type];e(r.currentTarget,f,(function(){return o(d)})),s.appendChild(p),window.getComputedStyle(p).getPropertyValue("opacity");var m=s.getBoundingClientRect(),v=0,h=0;/mouse|pointer|touch/.test(r.type)?(v=r.clientX-m.left,h=r.clientY-m.top):(v=m.width/2,h=m.height/2);var k=v-(v<m.width/2?m.width:0),w=h-(h<m.height/2?m.height:0),g=2*Math.sqrt(k*k+w*w);if(u.style.width=u.style.height=g+"px",u.offsetWidth<0)throw new Error("Inconceivable!");u.style.cssText="\n        width: "+g+"px;\n        height: "+g+"px;\n        transform: translate(-50%, -50%) scale(1);\n        left: "+v+"px;\n        top: "+h+"px;\n    ",setTimeout((function(){return n(d)}),500)}}},n=function(e){e.animated=!0,i(e)},o=function(e){e.released=!0,i(e)},i=function(t){if(t.released&&t.animated){var n=t.blob,o=t.ripple,i=t.container;i&&e(i,"blur",(function(){return i.classList.remove("k-ripple-target")})),n&&(e(n,"transitionend",(function(){o&&o.parentNode&&o.parentNode.removeChild(o)})),n.style.transition="opacity 200ms linear",n.style.opacity="0")}};kendo.deepExtend(kendo.util.ripple,{register:function(e,n){var o,i=(o=n.map((function(n){var o={events:["mousedown","touchdown"],global:!1},i=n.selector,r=n.options,s=void 0===r?o:r,a=t(i,s),c=s.events||o.events,l=s.global?document.body:e;return c.forEach((function(e){return l.addEventListener(e,a,!1)})),{events:c,options:s,activator:a}})),[].concat.apply([],o));return function(){if(e){i.forEach((function(t){var n=t.events,o=t.options,i=t.activator,r=o.global?document.body:e;n.forEach((function(e){return r.removeEventListener(e,i,!1)}))})),e=null}}}})}();var __meta__={id:"ripplecontainer",name:"RippleContainer",category:"web",depends:["core"]};!function(e,t){var n=window.kendo,o=n.ui,i=o.Widget,r=e.extend,s=n.util.ripple,a=i.extend({init:function(e,t){var n=this;i.fn.init.call(n,e),(e=n.wrapper=n.element).addClass("k-ripple-container"),n.options=r({},n.options,t),n.registerListeners()},options:{name:"RippleContainer",elements:[{selector:".k-button:not(li)"},{selector:".k-list-ul > .k-list-item",options:{global:!0}},{selector:".k-checkbox-label, .k-radio-label"},{selector:".k-checkbox, .k-radio",options:{events:["focusin","animationend","click"]}}]},removeListeners:function(){},registerListeners:function(){var e=this,t=e.element[0],n=e.options.elements;e.removeListeners();var o=s.register(t,n);e.removeListeners=o},destroy:function(){i.fn.destroy.call(this),this.removeListeners()}});o.plugin(a)}(window.kendo.jQuery);var kendo$1=kendo;export{kendo$1 as default};
//# sourceMappingURL=kendo.ripple.js.map
