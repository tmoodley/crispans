(window.webpackJsonp=window.webpackJsonp||[]).push([[1],{132:function(t,e,s){},133:function(t,e,s){"use strict";var a=s(132);s.n(a).a},134:function(t,e,s){"use strict";s.r(e);var a=s(47),r=s.n(a),i=s(1),o=s.n(i),l=s(44);function c(t,e){var s=Object.keys(t);if(Object.getOwnPropertySymbols){var a=Object.getOwnPropertySymbols(t);e&&(a=a.filter((function(e){return Object.getOwnPropertyDescriptor(t,e).enumerable}))),s.push.apply(s,a)}return s}var n={data:function(){return{email:_user,loading:!1,purchaseOrder:{PurchaseDate:"",DeliveryDate:"",Notes:"",PurchaseOrderNumber:"",CustomerId:"",Email:_user,Status:"",SubTotal:0,Tax:0,Total:0,PurchaseOrderItems:[{Item:"",Description:"",Quantity:0,Amount:0}]}}},methods:function(t){for(var e=1;e<arguments.length;e++){var s=null!=arguments[e]?arguments[e]:{};e%2?c(Object(s),!0).forEach((function(e){r()(t,e,s[e])})):Object.getOwnPropertyDescriptors?Object.defineProperties(t,Object.getOwnPropertyDescriptors(s)):c(Object(s)).forEach((function(e){Object.defineProperty(t,e,Object.getOwnPropertyDescriptor(s,e))}))}return t}({},Object(l.mapActions)("company",["getCompany"]),{},Object(l.mapActions)("purchaseOrder",["getPurchaseOrder"]),{save:function(){event.preventDefault();var t=this;return this.purchaseOrder.CustomerId=this.store.company.id,o.a.post("/api/purchaseorders/",t.purchaseOrder).then((function(e){t.purchaseOrder=e.data}))},onComplete:function(){var t=this;this.save().then((function(){t.$swal.fire("Saved","Job Saved","success").then((function(){window.location.href="/purchaseorders/details/"+t.purchaseOrder.id}))}))},addLine:function(){this.purchaseOrder.PurchaseOrderItems.push({Item:"",Description:"",Quantity:0,Amount:0})},addTotal:function(){var t=this;this.purchaseOrder.PurchaseOrderItems.map((function(e){t.purchaseOrder.Total+=e.quantity*e.amount}))},removeLine:function(t){var e=this.purchaseOrder.PurchaseOrderItems.indexOf(t);t>-1&&this.purchaseOrder.PurchaseOrderItems.splice(e,1)}}),created:function(){this.debouncedGetAnswer=_.debounce(this.addTotal,500)},mounted:function(){this.getCompany(this.email);var t=this;this.getPurchaseOrder(this.$route.params.id).then((function(){t.purchaseOrder=t.store}))},computed:Object(l.mapState)({store:function(t){return t.purchaseOrder}})},d=(s(133),s(32)),u=Object(d.a)(n,(function(){var t=this,e=t.$createElement,s=t._self._c||e;return s("div",[s("nav-menu",{attrs:{params:"route: route"}}),t._v(" "),s("h1",[t._v("Manage")]),t._v(" "),s("div",{staticClass:"container"},[s("div",{staticClass:"row"},[s("div",{staticClass:"col-md-12"},[s("div",{staticClass:"panel-group",attrs:{id:"accordion"}},[s("div",{staticClass:"panel panel-default"},[t._m(0),t._v(" "),s("div",{staticClass:"panel-collapse collapse in",attrs:{id:"collapseOne"}},[s("div",{staticClass:"panel-body"},[s("form",{on:{submit:t.onComplete}},[t._m(1),t._v(" "),s("div",{staticClass:"row"},[s("div",{staticClass:"col-md-6"},[s("div",{staticClass:"form-group"},[s("label",{staticClass:"control-label",attrs:{for:"PurchaseDate"}},[t._v("Purchase Date")]),t._v(" "),s("input",{directives:[{name:"model",rawName:"v-model",value:t.purchaseOrder.PurchaseDate,expression:"purchaseOrder.PurchaseDate"}],staticClass:"form-control",attrs:{type:"date"},domProps:{value:t.purchaseOrder.PurchaseDate},on:{input:function(e){e.target.composing||t.$set(t.purchaseOrder,"PurchaseDate",e.target.value)}}})])]),t._v(" "),s("div",{staticClass:"col-md-6"},[s("div",{staticClass:"form-group"},[s("label",{staticClass:"control-label",attrs:{for:"DeliveryDate"}},[t._v("Delivery Date")]),t._v(" "),s("input",{directives:[{name:"model",rawName:"v-model",value:t.purchaseOrder.DeliveryDate,expression:"purchaseOrder.DeliveryDate"}],staticClass:"form-control",attrs:{type:"date"},domProps:{value:t.purchaseOrder.DeliveryDate},on:{input:function(e){e.target.composing||t.$set(t.purchaseOrder,"DeliveryDate",e.target.value)}}})])]),t._v(" "),s("div",{staticClass:"col-md-6"},[s("div",{staticClass:"form-group"},[s("label",{staticClass:"control-label",attrs:{for:"PurchaseOrderNumber"}},[t._v("Purchase Order Number")]),t._v(" "),s("input",{directives:[{name:"model",rawName:"v-model",value:t.purchaseOrder.PurchaseOrderNumber,expression:"purchaseOrder.PurchaseOrderNumber"}],staticClass:"form-control",domProps:{value:t.purchaseOrder.PurchaseOrderNumber},on:{input:function(e){e.target.composing||t.$set(t.purchaseOrder,"PurchaseOrderNumber",e.target.value)}}})])])]),t._v(" "),t._m(2),t._v(" "),t._l(t.purchaseOrder.PurchaseOrderItems,(function(e,a){return s("div",{staticClass:"row"},[s("div",{staticClass:"col-md-3"},[s("div",{staticClass:"form-group"},[s("input",{directives:[{name:"model",rawName:"v-model",value:e.item,expression:"item.item"}],staticClass:"form-control",attrs:{type:"text",placeholder:"Item"},domProps:{value:e.item},on:{input:function(s){s.target.composing||t.$set(e,"item",s.target.value)}}})])]),t._v(" "),s("div",{staticClass:"col-md-4"},[s("div",{staticClass:"form-group"},[s("input",{directives:[{name:"model",rawName:"v-model",value:e.description,expression:"item.description"}],staticClass:"form-control",attrs:{type:"text",placeholder:"Description"},domProps:{value:e.description},on:{input:function(s){s.target.composing||t.$set(e,"description",s.target.value)}}})])]),t._v(" "),s("div",{staticClass:"col-md-2"},[s("div",{staticClass:"form-group"},[s("input",{directives:[{name:"model",rawName:"v-model",value:e.quantity,expression:"item.quantity"}],staticClass:"form-control",attrs:{type:"number",placeholder:"Quantity"},domProps:{value:e.quantity},on:{input:function(s){s.target.composing||t.$set(e,"quantity",s.target.value)}}})])]),t._v(" "),s("div",{staticClass:"col-md-2"},[s("div",{staticClass:"form-group"},[s("input",{directives:[{name:"model",rawName:"v-model",value:e.amount,expression:"item.amount"}],staticClass:"form-control",attrs:{type:"text",placeholder:"Amount"},domProps:{value:e.amount},on:{change:function(e){return t.debouncedGetAnswer()},input:function(s){s.target.composing||t.$set(e,"amount",s.target.value)}}})])]),t._v(" "),s("div",{staticClass:"col-md-1"},[e.amount>0?s("div",{staticClass:"form-group"},[t._v("\n                        "+t._s(t._f("currency")(e.amount*e.quantity))+"\n                      ")]):t._e(),t._v(" "),s("i",{staticClass:"fa fa-minus-circle",on:{click:function(e){return t.removeLine(a)}}})])])})),t._v(" "),s("div",{staticClass:"row"},[s("div",{staticClass:"col-md-12"},[s("i",{staticClass:"fa fa-plus-circle",on:{click:function(e){return t.addLine()}}},[t._v(" Add New Line")])])]),t._v(" "),s("div",{staticClass:"row"},[s("div",{staticClass:"col-md-8 total-footer"},[s("div",{staticClass:"total-footer__notes grid-5 grid-item"},[s("label",{staticClass:"control-label",attrs:{for:"notes"}},[t._v("Notes / Memo")]),t._v(" "),s("textarea",{directives:[{name:"model",rawName:"v-model",value:t.purchaseOrder.Notes,expression:"purchaseOrder.Notes"}],staticClass:"form-control",attrs:{name:"notes",id:"notes"},domProps:{value:t.purchaseOrder.Notes},on:{input:function(e){e.target.composing||t.$set(t.purchaseOrder,"Notes",e.target.value)}}})])]),t._v(" "),s("div",{staticClass:"col-md-4"},[s("div",{staticClass:"summary-grid"},[s("div",{staticClass:"summary-total"},[s("h5",{staticClass:"total-label"},[t._v("\n                            Total\n                          ")]),t._v(" "),s("span",{staticClass:"PurchaseOrderTotal",attrs:{id:"Total"}},[t._v(t._s(t._f("currency")(t.purchaseOrder.Total)))])])]),t._v(" "),s("div",{staticClass:"form-group"},[s("input",{staticClass:"btn btn-primary",attrs:{type:"submit",value:"Create",disabled:0==t.purchaseOrder.PurchaseOrderItems.length}})])])])],2)])])]),t._v(" "),t._m(3),t._v(" "),t._m(4)])])])])],1)}),[function(){var t=this.$createElement,e=this._self._c||t;return e("div",{staticClass:"panel-heading"},[e("h4",{staticClass:"panel-title"},[e("a",{attrs:{"data-toggle":"collapse","data-parent":"#accordion",href:"#collapseOne"}},[e("span",{staticClass:"glyphicon glyphicon-file"}),this._v("Purchase Order\n                ")])])])},function(){var t=this.$createElement,e=this._self._c||t;return e("div",{staticClass:"row"},[e("div",{staticClass:"col-md-9 pull-left"},[e("span",[this._v("Enter the details for your order")])]),this._v(" "),e("div",{staticClass:"col-md-3 pull-right"},[e("span",[this._v("STEP 1 OF 2")])])])},function(){var t=this.$createElement,e=this._self._c||t;return e("div",{staticClass:"row"},[e("div",{staticClass:"col-md-9 pull-left"},[e("span",[this._v("Enter the items you wish to order")])]),this._v(" "),e("div",{staticClass:"col-md-3 pull-right"},[e("span",[this._v("STEP 2 OF 2")])])])},function(){var t=this.$createElement,e=this._self._c||t;return e("div",{staticClass:"panel panel-default"},[e("div",{staticClass:"panel-heading"},[e("h4",{staticClass:"panel-title"},[e("a",{attrs:{"data-toggle":"collapse","data-parent":"#accordion",href:"#collapseTwo"}},[e("span",{staticClass:"glyphicon glyphicon-th-list"}),this._v("Documents\n                ")])])]),this._v(" "),e("div",{staticClass:"panel-collapse collapse",attrs:{id:"collapseTwo"}},[e("div",{staticClass:"panel-body"},[e("div",{staticClass:"row"},[e("div",{staticClass:"col-md-12"},[e("div",{staticClass:"form-group"},[e("input",{staticClass:"form-control",attrs:{type:"text",placeholder:"Title",required:""}})]),this._v(" "),e("div",{staticClass:"form-group"},[e("input",{staticClass:"form-control",attrs:{type:"text",placeholder:"Description",required:""}})]),this._v(" "),e("div",{staticClass:"form-group"},[e("textarea",{staticClass:"form-control",attrs:{placeholder:"Keywords",required:""}})])])]),this._v(" "),e("div",{staticClass:"row"},[e("div",{staticClass:"col-md-12"},[e("div",{staticClass:"well well-sm well-primary"},[e("form",{staticClass:"form form-inline ",attrs:{role:"form"}},[e("div",{staticClass:"form-group"},[e("a",{staticClass:"btn btn-success btn-sm",attrs:{href:"http://www.jquery2dotnet.com"}},[e("span",{staticClass:"glyphicon glyphicon-floppy-disk"}),this._v("Save\n                          ")])])])])])])])])])},function(){var t=this.$createElement,e=this._self._c||t;return e("div",{staticClass:"panel panel-default"},[e("div",{staticClass:"panel-heading"},[e("h4",{staticClass:"panel-title"},[e("a",{attrs:{"data-toggle":"collapse","data-parent":"#accordion",href:"#collapseThree"}},[e("span",{staticClass:"glyphicon glyphicon-th-list"}),this._v("Categories\n                ")])])]),this._v(" "),e("div",{staticClass:"panel-collapse collapse",attrs:{id:"collapseThree"}},[e("div",{staticClass:"panel-body"},[e("div",{staticClass:"row"},[e("div",{staticClass:"col-md-12"},[e("div",{staticClass:"form-group"},[e("input",{staticClass:"form-control",attrs:{type:"text",placeholder:"Title",required:""}})]),this._v(" "),e("div",{staticClass:"form-group"},[e("input",{staticClass:"form-control",attrs:{type:"text",placeholder:"Description",required:""}})]),this._v(" "),e("div",{staticClass:"form-group"},[e("textarea",{staticClass:"form-control",attrs:{placeholder:"Keywords",required:""}})])])]),this._v(" "),e("div",{staticClass:"row"},[e("div",{staticClass:"col-md-12"},[e("div",{staticClass:"well well-sm well-primary"},[e("form",{staticClass:"form form-inline ",attrs:{role:"form"}},[e("div",{staticClass:"form-group"},[e("a",{staticClass:"btn btn-success btn-sm",attrs:{href:"http://www.jquery2dotnet.com"}},[e("span",{staticClass:"glyphicon glyphicon-floppy-disk"}),this._v("Save\n                          ")])])])])])])])])])}],!1,null,null,null);e.default=u.exports}}]);