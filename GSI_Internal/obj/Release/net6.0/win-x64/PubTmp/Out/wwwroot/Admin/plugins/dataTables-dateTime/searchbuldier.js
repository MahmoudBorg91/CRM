/*!
 SearchBuilder 1.3.4
 ©SpryMedia Ltd - datatables.net/license/mit
*/
var $jscomp = $jscomp || {}; $jscomp.scope = {}; $jscomp.ASSUME_ES5 = !1; $jscomp.ASSUME_NO_NATIVE_MAP = !1; $jscomp.ASSUME_NO_NATIVE_SET = !1; $jscomp.SIMPLE_FROUND_POLYFILL = !1; $jscomp.ISOLATE_POLYFILLS = !1; $jscomp.defineProperty = $jscomp.ASSUME_ES5 || "function" == typeof Object.defineProperties ? Object.defineProperty : function (k, n, m) { if (k == Array.prototype || k == Object.prototype) return k; k[n] = m.value; return k };
$jscomp.getGlobal = function (k) { k = ["object" == typeof globalThis && globalThis, k, "object" == typeof window && window, "object" == typeof self && self, "object" == typeof global && global]; for (var n = 0; n < k.length; ++n) { var m = k[n]; if (m && m.Math == Math) return m } throw Error("Cannot find global object"); }; $jscomp.global = $jscomp.getGlobal(this); $jscomp.IS_SYMBOL_NATIVE = "function" === typeof Symbol && "symbol" === typeof Symbol("x"); $jscomp.TRUST_ES6_POLYFILLS = !$jscomp.ISOLATE_POLYFILLS || $jscomp.IS_SYMBOL_NATIVE; $jscomp.polyfills = {};
$jscomp.propertyToPolyfillSymbol = {}; $jscomp.POLYFILL_PREFIX = "$jscp$"; var $jscomp$lookupPolyfilledValue = function (k, n) { var m = $jscomp.propertyToPolyfillSymbol[n]; if (null == m) return k[n]; m = k[m]; return void 0 !== m ? m : k[n] }; $jscomp.polyfill = function (k, n, m, h) { n && ($jscomp.ISOLATE_POLYFILLS ? $jscomp.polyfillIsolated(k, n, m, h) : $jscomp.polyfillUnisolated(k, n, m, h)) };
$jscomp.polyfillUnisolated = function (k, n, m, h) { m = $jscomp.global; k = k.split("."); for (h = 0; h < k.length - 1; h++) { var r = k[h]; if (!(r in m)) return; m = m[r] } k = k[k.length - 1]; h = m[k]; n = n(h); n != h && null != n && $jscomp.defineProperty(m, k, { configurable: !0, writable: !0, value: n }) };
$jscomp.polyfillIsolated = function (k, n, m, h) {
    var r = k.split("."); k = 1 === r.length; h = r[0]; h = !k && h in $jscomp.polyfills ? $jscomp.polyfills : $jscomp.global; for (var q = 0; q < r.length - 1; q++) { var v = r[q]; if (!(v in h)) return; h = h[v] } r = r[r.length - 1]; m = $jscomp.IS_SYMBOL_NATIVE && "es6" === m ? h[r] : null; n = n(m); null != n && (k ? $jscomp.defineProperty($jscomp.polyfills, r, { configurable: !0, writable: !0, value: n }) : n !== m && ($jscomp.propertyToPolyfillSymbol[r] = $jscomp.IS_SYMBOL_NATIVE ? $jscomp.global.Symbol(r) : $jscomp.POLYFILL_PREFIX + r, r =
        $jscomp.propertyToPolyfillSymbol[r], $jscomp.defineProperty(h, r, { configurable: !0, writable: !0, value: n })))
}; $jscomp.polyfill("Object.is", function (k) { return k ? k : function (n, m) { return n === m ? 0 !== n || 1 / n === 1 / m : n !== n && m !== m } }, "es6", "es3"); $jscomp.polyfill("Array.prototype.includes", function (k) { return k ? k : function (n, m) { var h = this; h instanceof String && (h = String(h)); var r = h.length; m = m || 0; for (0 > m && (m = Math.max(m + r, 0)); m < r; m++) { var q = h[m]; if (q === n || Object.is(q, n)) return !0 } return !1 } }, "es7", "es3");
$jscomp.checkStringArgs = function (k, n, m) { if (null == k) throw new TypeError("The 'this' value for String.prototype." + m + " must not be null or undefined"); if (n instanceof RegExp) throw new TypeError("First argument to String.prototype." + m + " must not be a regular expression"); return k + "" }; $jscomp.polyfill("String.prototype.includes", function (k) { return k ? k : function (n, m) { return -1 !== $jscomp.checkStringArgs(this, n, "includes").indexOf(n, m || 0) } }, "es6", "es3");
$jscomp.arrayIteratorImpl = function (k) { var n = 0; return function () { return n < k.length ? { done: !1, value: k[n++] } : { done: !0 } } }; $jscomp.arrayIterator = function (k) { return { next: $jscomp.arrayIteratorImpl(k) } }; $jscomp.initSymbol = function () { };
$jscomp.polyfill("Symbol", function (k) { if (k) return k; var n = function (r, q) { this.$jscomp$symbol$id_ = r; $jscomp.defineProperty(this, "description", { configurable: !0, writable: !0, value: q }) }; n.prototype.toString = function () { return this.$jscomp$symbol$id_ }; var m = 0, h = function (r) { if (this instanceof h) throw new TypeError("Symbol is not a constructor"); return new n("jscomp_symbol_" + (r || "") + "_" + m++, r) }; return h }, "es6", "es3"); $jscomp.initSymbolIterator = function () { };
$jscomp.polyfill("Symbol.iterator", function (k) { if (k) return k; k = Symbol("Symbol.iterator"); for (var n = "Array Int8Array Uint8Array Uint8ClampedArray Int16Array Uint16Array Int32Array Uint32Array Float32Array Float64Array".split(" "), m = 0; m < n.length; m++) { var h = $jscomp.global[n[m]]; "function" === typeof h && "function" != typeof h.prototype[k] && $jscomp.defineProperty(h.prototype, k, { configurable: !0, writable: !0, value: function () { return $jscomp.iteratorPrototype($jscomp.arrayIteratorImpl(this)) } }) } return k }, "es6",
    "es3"); $jscomp.initSymbolAsyncIterator = function () { }; $jscomp.iteratorPrototype = function (k) { k = { next: k }; k[Symbol.iterator] = function () { return this }; return k }; $jscomp.iteratorFromArray = function (k, n) { k instanceof String && (k += ""); var m = 0, h = { next: function () { if (m < k.length) { var r = m++; return { value: n(r, k[r]), done: !1 } } h.next = function () { return { done: !0, value: void 0 } }; return h.next() } }; h[Symbol.iterator] = function () { return h }; return h };
$jscomp.polyfill("Array.prototype.keys", function (k) { return k ? k : function () { return $jscomp.iteratorFromArray(this, function (n) { return n }) } }, "es6", "es3"); $jscomp.polyfill("String.prototype.startsWith", function (k) { return k ? k : function (n, m) { var h = $jscomp.checkStringArgs(this, n, "startsWith"); n += ""; var r = h.length, q = n.length; m = Math.max(0, Math.min(m | 0, h.length)); for (var v = 0; v < q && m < r;)if (h[m++] != n[v++]) return !1; return v >= q } }, "es6", "es3");
$jscomp.polyfill("String.prototype.endsWith", function (k) { return k ? k : function (n, m) { var h = $jscomp.checkStringArgs(this, n, "endsWith"); n += ""; void 0 === m && (m = h.length); m = Math.max(0, Math.min(m | 0, h.length)); for (var r = n.length; 0 < r && 0 < m;)if (h[--m] != n[--r]) return !1; return 0 >= r } }, "es6", "es3");
(function () {
    function k(c) { h = c; r = c.fn.dataTable } function n(c) { v = c; C = c.fn.dataTable } function m(c) { w = c; B = c.fn.DataTable } var h, r, q = function () {
        function c(a, b, d, e, f, g) {
            var l = this; void 0 === e && (e = 0); void 0 === f && (f = 1); void 0 === g && (g = void 0); if (!r || !r.versionCheck || !r.versionCheck("1.10.0")) throw Error("SearchPane requires DataTables 1.10 or newer"); this.classes = h.extend(!0, {}, c.classes); this.c = h.extend(!0, {}, c.defaults, h.fn.dataTable.ext.searchBuilder, b); b = this.c.i18n; this.s = {
                condition: void 0, conditions: {},
                data: void 0, dataIdx: -1, dataPoints: [], dateFormat: !1, depth: f, dt: a, filled: !1, index: e, origData: void 0, preventRedraw: !1, serverData: g, topGroup: d, type: "", value: []
            }; this.dom = {
                buttons: h("<div/>").addClass(this.classes.buttonContainer), condition: h("<select disabled/>").addClass(this.classes.condition).addClass(this.classes.dropDown).addClass(this.classes.italic).attr("autocomplete", "hacking"), conditionTitle: h('<option value="" disabled selected hidden/>').html(this.s.dt.i18n("searchBuilder.condition", b.condition)),
                container: h("<div/>").addClass(this.classes.container), data: h("<select/>").addClass(this.classes.data).addClass(this.classes.dropDown).addClass(this.classes.italic), dataTitle: h('<option value="" disabled selected hidden/>').html(this.s.dt.i18n("searchBuilder.data", b.data)), defaultValue: h("<select disabled/>").addClass(this.classes.value).addClass(this.classes.dropDown).addClass(this.classes.select).addClass(this.classes.italic), "delete": h("<button/>").html(this.s.dt.i18n("searchBuilder.delete", b["delete"])).addClass(this.classes["delete"]).addClass(this.classes.button).attr("title",
                    this.s.dt.i18n("searchBuilder.deleteTitle", b.deleteTitle)).attr("type", "button"), inputCont: h("<div/>").addClass(this.classes.inputCont), left: h("<button/>").html(this.s.dt.i18n("searchBuilder.left", b.left)).addClass(this.classes.left).addClass(this.classes.button).attr("title", this.s.dt.i18n("searchBuilder.leftTitle", b.leftTitle)).attr("type", "button"), right: h("<button/>").html(this.s.dt.i18n("searchBuilder.right", b.right)).addClass(this.classes.right).addClass(this.classes.button).attr("title", this.s.dt.i18n("searchBuilder.rightTitle",
                        b.rightTitle)).attr("type", "button"), value: [h("<select disabled/>").addClass(this.classes.value).addClass(this.classes.dropDown).addClass(this.classes.italic).addClass(this.classes.select)], valueTitle: h('<option value="--valueTitle--" disabled selected hidden/>').html(this.s.dt.i18n("searchBuilder.value", b.value))
            }; if (this.c.greyscale) for (this.dom.data.addClass(this.classes.greyscale), this.dom.condition.addClass(this.classes.greyscale), this.dom.defaultValue.addClass(this.classes.greyscale), a = 0, d =
                this.dom.value; a < d.length; a++)d[a].addClass(this.classes.greyscale); h(window).on("resize.dtsb", r.util.throttle(function () { l.s.topGroup.trigger("dtsb-redrawLogic") })); this._buildCriteria(); return this
        } c._escapeHTML = function (a) { return a.toString().replace(/&amp;/g, "&").replace(/&lt;/g, "<").replace(/&gt;/g, ">").replace(/&quot;/g, '"') }; c.parseNumFmt = function (a) { return +a.replace(/(?!^-)[^0-9.]/g, "") }; c.prototype.updateArrows = function (a) {
            void 0 === a && (a = !1); this.dom.container.children().detach(); this.dom.container.append(this.dom.data).append(this.dom.condition).append(this.dom.inputCont);
            this.setListeners(); void 0 !== this.dom.value[0] && this.dom.value[0].trigger("dtsb-inserted"); for (var b = 1; b < this.dom.value.length; b++)this.dom.inputCont.append(this.dom.value[b]), this.dom.value[b].trigger("dtsb-inserted"); 1 < this.s.depth && this.dom.buttons.append(this.dom.left); (!1 === this.c.depthLimit || this.s.depth < this.c.depthLimit) && a ? this.dom.buttons.append(this.dom.right) : this.dom.right.remove(); this.dom.buttons.append(this.dom["delete"]); this.dom.container.append(this.dom.buttons)
        }; c.prototype.destroy =
            function () { this.dom.data.off(".dtsb"); this.dom.condition.off(".dtsb"); this.dom["delete"].off(".dtsb"); for (var a = 0, b = this.dom.value; a < b.length; a++)b[a].off(".dtsb"); this.dom.container.remove() }; c.prototype.search = function (a, b) {
                var d = this.s.conditions[this.s.condition]; if (void 0 !== this.s.condition && void 0 !== d) {
                    var e = a[this.s.dataIdx]; if (this.s.type.includes("num") && ("" !== this.s.dt.settings()[0].oLanguage.sDecimal || "" !== this.s.dt.settings()[0].oLanguage.sThousands)) {
                        e = [a[this.s.dataIdx]]; "" !== this.s.dt.settings()[0].oLanguage.sDecimal &&
                            (e = a[this.s.dataIdx].split(this.s.dt.settings()[0].oLanguage.sDecimal)); if ("" !== this.s.dt.settings()[0].oLanguage.sThousands) for (a = 0; a < e.length; a++)e[a] = e[a].replace(this.s.dt.settings()[0].oLanguage.sThousands, ","); e = e.join(".")
                    } "filter" !== this.c.orthogonal.search && (e = this.s.dt.settings()[0], e = e.oApi._fnGetCellData(e, b, this.s.dataIdx, "string" === typeof this.c.orthogonal ? this.c.orthogonal : this.c.orthogonal.search)); if ("array" === this.s.type) for (Array.isArray(e) || (e = [e]), e.sort(), b = 0, a = e; b < a.length; b++) {
                        var f =
                            a[b]; f && "string" === typeof f && f.replace(/[\r\n\u2028]/g, " ")
                    } else null !== e && "string" === typeof e && (e = e.replace(/[\r\n\u2028]/g, " ")); this.s.type.includes("html") && "string" === typeof e && (e = e.replace(/(<([^>]+)>)/ig, "")); null === e && (e = ""); return d.search(e, this.s.value, this)
                }
            }; c.prototype.getDetails = function (a) {
                void 0 === a && (a = !1); if (null !== this.s.type && this.s.type.includes("num") && ("" !== this.s.dt.settings()[0].oLanguage.sDecimal || "" !== this.s.dt.settings()[0].oLanguage.sThousands)) for (a = 0; a < this.s.value.length; a++) {
                    var b =
                        [this.s.value[a].toString()]; "" !== this.s.dt.settings()[0].oLanguage.sDecimal && (b = this.s.value[a].split(this.s.dt.settings()[0].oLanguage.sDecimal)); if ("" !== this.s.dt.settings()[0].oLanguage.sThousands) for (var d = 0; d < b.length; d++)b[d] = b[d].replace(this.s.dt.settings()[0].oLanguage.sThousands, ","); this.s.value[a] = b.join(".")
                } else if (null !== this.s.type && a) if (this.s.type.includes("date") || this.s.type.includes("time")) for (a = 0; a < this.s.value.length; a++)null === this.s.value[a].match(/^\d{4}-([0]\d|1[0-2])-([0-2]\d|3[01])$/g) &&
                    (this.s.value[a] = ""); else if (this.s.type.includes("moment")) for (a = 0; a < this.s.value.length; a++)this.s.value[a] && 0 < this.s.value[a].length && (0, window.moment)(this.s.value[a], this.s.dateFormat, !0).isValid() && (this.s.value[a] = (0, window.moment)(this.s.value[a], this.s.dateFormat).format("YYYY-MM-DD HH:mm:ss")); else if (this.s.type.includes("luxon")) for (a = 0; a < this.s.value.length; a++)this.s.value[a] && 0 < this.s.value[a].length && null === window.luxon.DateTime.fromFormat(this.s.value[a], this.s.dateFormat).invalid &&
                        (this.s.value[a] = window.luxon.DateTime.fromFormat(this.s.value[a], this.s.dateFormat).toFormat("yyyy-MM-dd HH:mm:ss")); if (this.s.type.includes("num") && this.s.dt.page.info().serverSide) for (a = 0; a < this.s.value.length; a++)this.s.value[a] = this.s.value[a].replace(/[^0-9.]/g, ""); return { condition: this.s.condition, data: this.s.data, origData: this.s.origData, type: this.s.type, value: this.s.value.map(function (e) { return null !== e && void 0 !== e ? e.toString() : e }) }
            }; c.prototype.getNode = function () { return this.dom.container };
        c.prototype.populate = function () { this._populateData(); -1 !== this.s.dataIdx && (this._populateCondition(), void 0 !== this.s.condition && this._populateValue()) }; c.prototype.rebuild = function (a) {
            var b = !1, d; this._populateData(); if (void 0 !== a.data) { var e = this.classes.italic, f = this.dom.data; this.dom.data.children("option").each(function () { !b && (h(this).text() === a.data || a.origData && h(this).prop("origData") === a.origData) ? (h(this).prop("selected", !0), f.removeClass(e), b = !0, d = h(this).val()) : h(this).removeProp("selected") }) } if (b) {
                this.s.data =
                a.data; this.s.origData = a.origData; this.s.dataIdx = d; this.c.orthogonal = this._getOptions().orthogonal; this.dom.dataTitle.remove(); this._populateCondition(); this.dom.conditionTitle.remove(); for (var g = void 0, l = this.dom.condition.children("option"), p = 0; p < l.length; p++) { var t = h(l[p]); void 0 !== a.condition && t.val() === a.condition && "string" === typeof a.condition ? (t.prop("selected", !0), g = t.val()) : t.removeProp("selected") } this.s.condition = g; if (void 0 !== this.s.condition) {
                    this.dom.conditionTitle.removeProp("selected");
                    this.dom.conditionTitle.remove(); this.dom.condition.removeClass(this.classes.italic); for (p = 0; p < l.length; p++)t = h(l[p]), t.val() !== this.s.condition && t.removeProp("selected"); this._populateValue(a)
                } else this.dom.conditionTitle.prependTo(this.dom.condition).prop("selected", !0)
            }
        }; c.prototype.setListeners = function () {
            var a = this; this.dom.data.unbind("change").on("change.dtsb", function () {
                a.dom.dataTitle.removeProp("selected"); for (var b = a.dom.data.children("option." + a.classes.option), d = 0; d < b.length; d++) {
                    var e =
                        h(b[d]); e.val() === a.dom.data.val() ? (a.dom.data.removeClass(a.classes.italic), e.prop("selected", !0), a.s.dataIdx = +e.val(), a.s.data = e.text(), a.s.origData = e.prop("origData"), a.c.orthogonal = a._getOptions().orthogonal, a._clearCondition(), a._clearValue(), a._populateCondition(), a.s.filled && (a.s.filled = !1, a.s.dt.draw(), a.setListeners()), a.s.dt.state.save()) : e.removeProp("selected")
                }
            }); this.dom.condition.unbind("change").on("change.dtsb", function () {
                a.dom.conditionTitle.removeProp("selected"); for (var b = a.dom.condition.children("option." +
                    a.classes.option), d = 0; d < b.length; d++) {
                        var e = h(b[d]); if (e.val() === a.dom.condition.val()) {
                            a.dom.condition.removeClass(a.classes.italic); e.prop("selected", !0); e = e.val(); for (var f = 0, g = Object.keys(a.s.conditions); f < g.length; f++)if (g[f] === e) { a.s.condition = e; break } a._clearValue(); a._populateValue(); e = 0; for (f = a.dom.value; e < f.length; e++)g = f[e], a.s.filled && void 0 !== g && 0 !== a.dom.inputCont.has(g[0]).length && (a.s.filled = !1, a.s.dt.draw(), a.setListeners()); (0 === a.dom.value.length || 1 === a.dom.value.length && void 0 ===
                                a.dom.value[0]) && a.s.dt.draw()
                        } else e.removeProp("selected")
                }
            })
        }; c.prototype.setupButtons = function () { 550 < window.innerWidth ? (this.dom.container.removeClass(this.classes.vertical), this.dom.buttons.css("left", null), this.dom.buttons.css("top", null)) : (this.dom.container.addClass(this.classes.vertical), this.dom.buttons.css("left", this.dom.data.innerWidth()), this.dom.buttons.css("top", this.dom.data.position().top)) }; c.prototype._buildCriteria = function () {
            this.dom.data.append(this.dom.dataTitle); this.dom.condition.append(this.dom.conditionTitle);
            this.dom.container.append(this.dom.data).append(this.dom.condition); this.dom.inputCont.empty(); for (var a = 0, b = this.dom.value; a < b.length; a++) { var d = b[a]; d.append(this.dom.valueTitle); this.dom.inputCont.append(d) } this.dom.buttons.append(this.dom["delete"]).append(this.dom.right); this.dom.container.append(this.dom.inputCont).append(this.dom.buttons); this.setListeners()
        }; c.prototype._clearCondition = function () {
            this.dom.condition.empty(); this.dom.conditionTitle.prop("selected", !0).attr("disabled", "true");
            this.dom.condition.prepend(this.dom.conditionTitle).prop("selectedIndex", 0); this.s.conditions = {}; this.s.condition = void 0
        }; c.prototype._clearValue = function () {
            if (void 0 !== this.s.condition) {
                if (0 < this.dom.value.length && void 0 !== this.dom.value[0]) for (var a = function (f) { void 0 !== f && setTimeout(function () { f.remove() }, 50) }, b = 0, d = this.dom.value; b < d.length; b++) { var e = d[b]; a(e) } this.dom.value = [].concat(this.s.conditions[this.s.condition].init(this, c.updateListener)); if (0 < this.dom.value.length && void 0 !== this.dom.value[0]) for (this.dom.inputCont.empty().append(this.dom.value[0]).insertAfter(this.dom.condition),
                    this.dom.value[0].trigger("dtsb-inserted"), e = 1; e < this.dom.value.length; e++)this.dom.inputCont.append(this.dom.value[e]), this.dom.value[e].trigger("dtsb-inserted")
            } else { a = function (f) { void 0 !== f && setTimeout(function () { f.remove() }, 50) }; b = 0; for (d = this.dom.value; b < d.length; b++)e = d[b], a(e); this.dom.valueTitle.prop("selected", !0); this.dom.defaultValue.append(this.dom.valueTitle).insertAfter(this.dom.condition) } this.s.value = []; this.dom.value = [h("<select disabled/>").addClass(this.classes.value).addClass(this.classes.dropDown).addClass(this.classes.italic).addClass(this.classes.select).append(this.dom.valueTitle.clone())]
        };
        c.prototype._getOptions = function () { return h.extend(!0, {}, c.defaults, this.s.dt.settings()[0].aoColumns[this.s.dataIdx].searchBuilder) }; c.prototype._populateCondition = function () {
            var a = [], b = Object.keys(this.s.conditions).length, d = this.s.dt.settings()[0].aoColumns, e = +this.dom.data.children("option:selected").val(); if (0 === b) {
                this.s.type = this.s.dt.columns().type().toArray()[e]; if (void 0 !== d) if (b = d[e], void 0 !== b.searchBuilderType && null !== b.searchBuilderType) this.s.type = b.searchBuilderType; else if (void 0 ===
                    this.s.type || null === this.s.type) this.s.type = b.sType; if (null === this.s.type || void 0 === this.s.type) h.fn.dataTable.ext.oApi._fnColumnTypes(this.s.dt.settings()[0]), this.s.type = this.s.dt.columns().type().toArray()[e]; this.dom.condition.removeAttr("disabled").empty().append(this.dom.conditionTitle).addClass(this.classes.italic); this.dom.conditionTitle.prop("selected", !0); b = this.s.dt.settings()[0].oLanguage.sDecimal; "" !== b && this.s.type.indexOf(b) === this.s.type.length - b.length && (this.s.type.includes("num-fmt") ?
                        this.s.type = this.s.type.replace(b, "") : this.s.type.includes("num") && (this.s.type = this.s.type.replace(b, ""))); var f = void 0 !== this.c.conditions[this.s.type] ? this.c.conditions[this.s.type] : this.s.type.includes("moment") ? this.c.conditions.moment : this.s.type.includes("luxon") ? this.c.conditions.luxon : this.c.conditions.string; this.s.type.includes("moment") ? this.s.dateFormat = this.s.type.replace(/moment-/g, "") : this.s.type.includes("luxon") && (this.s.dateFormat = this.s.type.replace(/luxon-/g, "")); for (var g = 0,
                            l = Object.keys(f); g < l.length; g++) { var p = l[g]; null !== f[p] && (this.s.dt.page.info().serverSide && f[p].init === c.initSelect && (b = d[e], this.s.serverData && this.s.serverData[b.data] ? (f[p].init = c.initSelectSSP, f[p].inputValue = c.inputValueSelect, f[p].isInputValid = c.isInputValidSelect) : (f[p].init = c.initInput, f[p].inputValue = c.inputValueInput, f[p].isInputValid = c.isInputValidInput)), this.s.conditions[p] = f[p], b = f[p].conditionName, "function" === typeof b && (b = b(this.s.dt, this.c.i18n)), a.push(h("<option>", { text: b, value: p }).addClass(this.classes.option).addClass(this.classes.notItalic))) }
            } else if (0 <
                b) for (this.dom.condition.empty().removeAttr("disabled").addClass(this.classes.italic), f = 0, g = Object.keys(this.s.conditions); f < g.length; f++)p = g[f], b = this.s.conditions[p].conditionName, "function" === typeof b && (b = b(this.s.dt, this.c.i18n)), p = h("<option>", { text: b, value: p }).addClass(this.classes.option).addClass(this.classes.notItalic), void 0 !== this.s.condition && this.s.condition === b && (p.prop("selected", !0), this.dom.condition.removeClass(this.classes.italic)), a.push(p); else {
                    this.dom.condition.attr("disabled",
                        "true").addClass(this.classes.italic); return
            } for (b = 0; b < a.length; b++)this.dom.condition.append(a[b]); if (d[e].searchBuilder && d[e].searchBuilder.defaultCondition) if (d = d[e].searchBuilder.defaultCondition, "number" === typeof d) this.dom.condition.prop("selectedIndex", d), this.dom.condition.trigger("change"); else {
                if ("string" === typeof d) for (e = 0; e < a.length; e++)for (p = 0, f = Object.keys(this.s.conditions); p < f.length; p++)if (g = f[p], b = this.s.conditions[g].conditionName, ("string" === typeof b ? b : b(this.s.dt, this.c.i18n)) ===
                    a[e].text() && g === d) { this.dom.condition.prop("selectedIndex", this.dom.condition.children().toArray().indexOf(a[e][0])).removeClass(this.classes.italic); this.dom.condition.trigger("change"); e = a.length; break }
            } else this.dom.condition.prop("selectedIndex", 0)
        }; c.prototype._populateData = function () {
            var a = this; this.dom.data.empty().append(this.dom.dataTitle); if (0 === this.s.dataPoints.length) this.s.dt.columns().every(function (g) {
                if (!0 === a.c.columns || a.s.dt.columns(a.c.columns).indexes().toArray().includes(g)) {
                    for (var l =
                        !1, p = 0, t = a.s.dataPoints; p < t.length; p++)if (t[p].index === g) { l = !0; break } l || (l = a.s.dt.settings()[0].aoColumns[g], g = { index: g, origData: l.data, text: (void 0 === l.searchBuilderTitle ? l.sTitle : l.searchBuilderTitle).replace(/(<([^>]+)>)/ig, "") }, a.s.dataPoints.push(g), a.dom.data.append(h("<option>", { text: g.text, value: g.index }).addClass(a.classes.option).addClass(a.classes.notItalic).prop("origData", l.data).prop("selected", a.s.dataIdx === g.index ? !0 : !1)), a.s.dataIdx === g.index && a.dom.dataTitle.removeProp("selected"))
                }
            });
            else for (var b = function (g) {
                d.s.dt.columns().every(function (p) { var t = a.s.dt.settings()[0].aoColumns[p]; (void 0 === t.searchBuilderTitle ? t.sTitle : t.searchBuilderTitle).replace(/(<([^>]+)>)/ig, "") === g.text && (g.index = p, g.origData = t.data) }); var l = h("<option>", { text: g.text.replace(/(<([^>]+)>)/ig, ""), value: g.index }).addClass(d.classes.option).addClass(d.classes.notItalic).prop("origData", g.origData); d.s.data === g.text && (d.s.dataIdx = g.index, d.dom.dataTitle.removeProp("selected"), l.prop("selected", !0), d.dom.data.removeClass(d.classes.italic));
                d.dom.data.append(l)
            }, d = this, e = 0, f = this.s.dataPoints; e < f.length; e++)b(f[e])
        }; c.prototype._populateValue = function (a) {
            var b = this, d = this.s.filled; this.s.filled = !1; setTimeout(function () { b.dom.defaultValue.remove() }, 50); for (var e = function (l) { setTimeout(function () { void 0 !== l && l.remove() }, 50) }, f = 0, g = this.dom.value; f < g.length; f++)e(g[f]); e = this.dom.inputCont.children(); if (1 < e.length) for (f = 0; f < e.length; f++)h(e[f]).remove(); void 0 !== a && this.s.dt.columns().every(function (l) {
                b.s.dt.settings()[0].aoColumns[l].sTitle ===
                a.data && (b.s.dataIdx = l)
            }); this.dom.value = [].concat(this.s.conditions[this.s.condition].init(this, c.updateListener, void 0 !== a ? a.value : void 0)); void 0 !== a && void 0 !== a.value && (this.s.value = a.value); this.dom.inputCont.empty(); void 0 !== this.dom.value[0] && this.dom.value[0].appendTo(this.dom.inputCont).trigger("dtsb-inserted"); for (f = 1; f < this.dom.value.length; f++)this.dom.value[f].insertAfter(this.dom.value[f - 1]).trigger("dtsb-inserted"); this.s.filled = this.s.conditions[this.s.condition].isInputValid(this.dom.value,
                this); this.setListeners(); this.s.preventRedraw || d === this.s.filled || (this.s.dt.page.info().serverSide || this.s.dt.draw(), this.setListeners())
        }; c.prototype._throttle = function (a, b) { void 0 === b && (b = 200); var d = null, e = null, f = this; null === b && (b = 200); return function () { for (var g = [], l = 0; l < arguments.length; l++)g[l] = arguments[l]; l = +new Date; null !== d && l < d + b ? clearTimeout(e) : d = l; e = setTimeout(function () { d = null; a.apply(f, g) }, b) } }; c.version = "1.1.0"; c.classes = {
            button: "dtsb-button", buttonContainer: "dtsb-buttonContainer",
            condition: "dtsb-condition", container: "dtsb-criteria", data: "dtsb-data", "delete": "dtsb-delete", dropDown: "dtsb-dropDown", greyscale: "dtsb-greyscale", input: "dtsb-input", inputCont: "dtsb-inputCont", italic: "dtsb-italic", joiner: "dtsp-joiner", left: "dtsb-left", notItalic: "dtsb-notItalic", option: "dtsb-option", right: "dtsb-right", select: "dtsb-select", value: "dtsb-value", vertical: "dtsb-vertical"
        }; c.initSelect = function (a, b, d, e) {
            void 0 === d && (d = null); void 0 === e && (e = !1); var f = a.dom.data.children("option:selected").val(),
                g = a.s.dt.rows().indexes().toArray(), l = a.s.dt.settings()[0]; a.dom.valueTitle.prop("selected", !0); var p = h("<select/>").addClass(c.classes.value).addClass(c.classes.dropDown).addClass(c.classes.italic).addClass(c.classes.select).append(a.dom.valueTitle).on("change.dtsb", function () { h(this).removeClass(c.classes.italic); b(a, this) }); a.c.greyscale && p.addClass(c.classes.greyscale); for (var t = [], A = [], F = 0; F < g.length; F++) {
                    var y = g[F], z = l.oApi._fnGetCellData(l, y, f, "string" === typeof a.c.orthogonal ? a.c.orthogonal :
                        a.c.orthogonal.search); z = "string" === typeof z ? z.replace(/[\r\n\u2028]/g, " ") : z; y = l.oApi._fnGetCellData(l, y, f, "string" === typeof a.c.orthogonal ? a.c.orthogonal : a.c.orthogonal.display); "array" === a.s.type && (z = Array.isArray(z) ? z : [z], y = Array.isArray(y) ? y : [y]); var H = function (u, x) {
                            a.s.type.includes("html") && null !== u && "string" === typeof u && u.replace(/(<([^>]+)>)/ig, ""); u = h("<option>", { type: Array.isArray(u) ? "Array" : "String", value: u }).data("sbv", u).addClass(a.classes.option).addClass(a.classes.notItalic).html("string" ===
                                typeof x ? x.replace(/(<([^>]+)>)/ig, "") : x); x = u.val(); -1 === t.indexOf(x) && (t.push(x), A.push(u), null !== d && Array.isArray(d[0]) && (d[0] = d[0].sort().join(",")), null !== d && u.val() === d[0] && (u.prop("selected", !0), p.removeClass(c.classes.italic), a.dom.valueTitle.removeProp("selected")))
                        }; if (e) for (var D = 0; D < z.length; D++)H(z[D], y[D]); else H(z, Array.isArray(y) ? y.join(", ") : y)
                } A.sort(function (u, x) {
                    if ("array" === a.s.type || "string" === a.s.type || "html" === a.s.type) return u.val() < x.val() ? -1 : u.val() > x.val() ? 1 : 0; if ("num" ===
                        a.s.type || "html-num" === a.s.type) return +u.val().replace(/(<([^>]+)>)/ig, "") < +x.val().replace(/(<([^>]+)>)/ig, "") ? -1 : +u.val().replace(/(<([^>]+)>)/ig, "") > +x.val().replace(/(<([^>]+)>)/ig, "") ? 1 : 0; if ("num-fmt" === a.s.type || "html-num-fmt" === a.s.type) return +u.val().replace(/[^0-9.]/g, "") < +x.val().replace(/[^0-9.]/g, "") ? -1 : +u.val().replace(/[^0-9.]/g, "") > +x.val().replace(/[^0-9.]/g, "") ? 1 : 0
                }); for (e = 0; e < A.length; e++)p.append(A[e]); return p
        }; c.initSelectSSP = function (a, b, d) {
            void 0 === d && (d = null); a.dom.valueTitle.prop("selected",
                !0); var e = h("<select/>").addClass(c.classes.value).addClass(c.classes.dropDown).addClass(c.classes.italic).addClass(c.classes.select).append(a.dom.valueTitle).on("change.dtsb", function () { h(this).removeClass(c.classes.italic); b(a, this) }); a.c.greyscale && e.addClass(c.classes.greyscale); for (var f = [], g = 0, l = a.s.serverData[a.s.origData]; g < l.length; g++) {
                    var p = l[g]; (function (t, A) {
                        a.s.type.includes("html") && null !== t && "string" === typeof t && t.replace(/(<([^>]+)>)/ig, ""); t = h("<option>", {
                            type: Array.isArray(t) ? "Array" :
                                "String", value: t
                        }).data("sbv", t).addClass(a.classes.option).addClass(a.classes.notItalic).html("string" === typeof A ? A.replace(/(<([^>]+)>)/ig, "") : A); f.push(t); null !== d && t.val() === d[0] && (t.prop("selected", !0), e.removeClass(c.classes.italic), a.dom.valueTitle.removeProp("selected"))
                    })(p.value, p.label)
                } for (g = 0; g < f.length; g++)e.append(f[g]); return e
        }; c.initSelectArray = function (a, b, d) { void 0 === d && (d = null); return c.initSelect(a, b, d, !0) }; c.initInput = function (a, b, d) {
            void 0 === d && (d = null); var e = a.s.dt.settings()[0].searchDelay;
            e = h("<input/>").addClass(c.classes.value).addClass(c.classes.input).on("input.dtsb keypress.dtsb", a._throttle(function (f) { return b(a, this, f.keyCode || f.which) }, null === e ? 100 : e)); a.c.greyscale && e.addClass(c.classes.greyscale); null !== d && e.val(d[0]); a.s.dt.one("draw.dtsb", function () { a.s.topGroup.trigger("dtsb-redrawLogic") }); return e
        }; c.init2Input = function (a, b, d) {
            void 0 === d && (d = null); var e = a.s.dt.settings()[0].searchDelay; e = [h("<input/>").addClass(c.classes.value).addClass(c.classes.input).on("input.dtsb keypress.dtsb",
                a._throttle(function (f) { return b(a, this, f.keyCode || f.which) }, null === e ? 100 : e)), h("<span>").addClass(a.classes.joiner).html(a.s.dt.i18n("searchBuilder.valueJoiner", a.c.i18n.valueJoiner)), h("<input/>").addClass(c.classes.value).addClass(c.classes.input).on("input.dtsb keypress.dtsb", a._throttle(function (f) { return b(a, this, f.keyCode || f.which) }, null === e ? 100 : e))]; a.c.greyscale && (e[0].addClass(c.classes.greyscale), e[2].addClass(c.classes.greyscale)); null !== d && (e[0].val(d[0]), e[2].val(d[1])); a.s.dt.one("draw.dtsb",
                    function () { a.s.topGroup.trigger("dtsb-redrawLogic") }); return e
        }; c.initDate = function (a, b, d) {
            void 0 === d && (d = null); var e = a.s.dt.settings()[0].searchDelay, f = h("<input/>").addClass(c.classes.value).addClass(c.classes.input).dtDateTime({ attachTo: "input", format: a.s.dateFormat ? a.s.dateFormat : void 0 }).on("change.dtsb", a._throttle(function () { return b(a, this) }, null === e ? 100 : e)).on("input.dtsb keypress.dtsb", function (g) { a._throttle(function () { return b(a, this, g.keyCode || g.which) }, null === e ? 100 : e) }); a.c.greyscale &&
                f.addClass(c.classes.greyscale); null !== d && f.val(d[0]); a.s.dt.one("draw.dtsb", function () { a.s.topGroup.trigger("dtsb-redrawLogic") }); return f
        }; c.initNoValue = function (a) { a.s.dt.one("draw.dtsb", function () { a.s.topGroup.trigger("dtsb-redrawLogic") }) }; c.init2Date = function (a, b, d) {
            var e = this; void 0 === d && (d = null); var f = a.s.dt.settings()[0].searchDelay, g = [h("<input/>").addClass(c.classes.value).addClass(c.classes.input).dtDateTime({ attachTo: "input", format: a.s.dateFormat ? a.s.dateFormat : void 0 }).on("change.dtsb",
                null !== f ? a.s.dt.settings()[0].oApi._fnThrottle(function () { return b(a, this) }, f) : function () { b(a, e) }).on("input.dtsb keypress.dtsb", function (l) { a.s.dt.settings()[0].oApi._fnThrottle(function () { return b(a, this, l.keyCode || l.which) }, null === f ? 0 : f) }), h("<span>").addClass(a.classes.joiner).html(a.s.dt.i18n("searchBuilder.valueJoiner", a.c.i18n.valueJoiner)), h("<input/>").addClass(c.classes.value).addClass(c.classes.input).dtDateTime({ attachTo: "input", format: a.s.dateFormat ? a.s.dateFormat : void 0 }).on("change.dtsb",
                    null !== f ? a.s.dt.settings()[0].oApi._fnThrottle(function () { return b(a, this) }, f) : function () { b(a, e) }).on("input.dtsb keypress.dtsb", a.c.enterSearch || void 0 !== a.s.dt.settings()[0].oInit.search && a.s.dt.settings()[0].oInit.search["return"] || null === f ? function (l) { b(a, e, l.keyCode || l.which) } : a.s.dt.settings()[0].oApi._fnThrottle(function () { return b(a, this) }, f))]; a.c.greyscale && (g[0].addClass(c.classes.greyscale), g[2].addClass(c.classes.greyscale)); null !== d && 0 < d.length && (g[0].val(d[0]), g[2].val(d[1])); a.s.dt.one("draw.dtsb",
                        function () { a.s.topGroup.trigger("dtsb-redrawLogic") }); return g
        }; c.isInputValidSelect = function (a) { for (var b = !0, d = 0; d < a.length; d++) { var e = a[d]; e.children("option:selected").length === e.children("option").length - e.children("option." + c.classes.notItalic).length && 1 === e.children("option:selected").length && e.children("option:selected")[0] === e.children("option")[0] && (b = !1) } return b }; c.isInputValidInput = function (a) { for (var b = !0, d = 0; d < a.length; d++) { var e = a[d]; e.is("input") && 0 === e.val().length && (b = !1) } return b };
        c.inputValueSelect = function (a) { for (var b = [], d = 0; d < a.length; d++) { var e = a[d]; e.is("select") && b.push(c._escapeHTML(e.children("option:selected").data("sbv"))) } return b }; c.inputValueInput = function (a) { for (var b = [], d = 0; d < a.length; d++) { var e = a[d]; e.is("input") && b.push(c._escapeHTML(e.val())) } return b }; c.updateListener = function (a, b, d) {
            var e = a.s.conditions[a.s.condition]; a.s.filled = e.isInputValid(a.dom.value, a); a.s.value = e.inputValue(a.dom.value, a); if (a.s.filled) {
                Array.isArray(a.s.value) || (a.s.value = [a.s.value]);
                for (e = 0; e < a.s.value.length; e++)if (Array.isArray(a.s.value[e])) a.s.value[e].sort(); else if (a.s.type.includes("num") && ("" !== a.s.dt.settings()[0].oLanguage.sDecimal || "" !== a.s.dt.settings()[0].oLanguage.sThousands)) {
                    var f = [a.s.value[e].toString()]; "" !== a.s.dt.settings()[0].oLanguage.sDecimal && (f = a.s.value[e].split(a.s.dt.settings()[0].oLanguage.sDecimal)); if ("" !== a.s.dt.settings()[0].oLanguage.sThousands) for (var g = 0; g < f.length; g++)f[g] = f[g].replace(a.s.dt.settings()[0].oLanguage.sThousands, ","); a.s.value[e] =
                        f.join(".")
                } g = f = null; for (e = 0; e < a.dom.value.length; e++)b === a.dom.value[e][0] && (f = e, void 0 !== b.selectionStart && (g = b.selectionStart)); (a.c.enterSearch || void 0 !== a.s.dt.settings()[0].oInit.search && a.s.dt.settings()[0].oInit.search["return"]) && 13 !== d || a.s.dt.draw(); null !== f && (a.dom.value[f].removeClass(a.classes.italic), a.dom.value[f].focus(), null !== g && a.dom.value[f][0].setSelectionRange(g, g))
            } else (a.c.enterSearch || void 0 !== a.s.dt.settings()[0].oInit.search && a.s.dt.settings()[0].oInit.search["return"]) &&
                13 !== d || a.s.dt.draw()
        }; c.dateConditions = {
            "=": { conditionName: function (a, b) { return a.i18n("searchBuilder.conditions.date.equals", b.conditions.date.equals) }, init: c.initDate, inputValue: c.inputValueInput, isInputValid: c.isInputValidInput, search: function (a, b) { a = a.replace(/(\/|-|,)/g, "-"); return a === b[0] } }, "!=": {
                conditionName: function (a, b) { return a.i18n("searchBuilder.conditions.date.not", b.conditions.date.not) }, init: c.initDate, inputValue: c.inputValueInput, isInputValid: c.isInputValidInput, search: function (a,
                    b) { a = a.replace(/(\/|-|,)/g, "-"); return a !== b[0] }
            }, "<": { conditionName: function (a, b) { return a.i18n("searchBuilder.conditions.date.before", b.conditions.date.before) }, init: c.initDate, inputValue: c.inputValueInput, isInputValid: c.isInputValidInput, search: function (a, b) { a = a.replace(/(\/|-|,)/g, "-"); return a < b[0] } }, ">": {
                conditionName: function (a, b) { return a.i18n("searchBuilder.conditions.date.after", b.conditions.date.after) }, init: c.initDate, inputValue: c.inputValueInput, isInputValid: c.isInputValidInput, search: function (a,
                    b) { a = a.replace(/(\/|-|,)/g, "-"); return a > b[0] }
            }, between: { conditionName: function (a, b) { return a.i18n("searchBuilder.conditions.date.between", b.conditions.date.between) }, init: c.init2Date, inputValue: c.inputValueInput, isInputValid: c.isInputValidInput, search: function (a, b) { a = a.replace(/(\/|-|,)/g, "-"); return b[0] < b[1] ? b[0] <= a && a <= b[1] : b[1] <= a && a <= b[0] } }, "!between": {
                conditionName: function (a, b) { return a.i18n("searchBuilder.conditions.date.notBetween", b.conditions.date.notBetween) }, init: c.init2Date, inputValue: c.inputValueInput,
                isInputValid: c.isInputValidInput, search: function (a, b) { a = a.replace(/(\/|-|,)/g, "-"); return b[0] < b[1] ? !(b[0] <= a && a <= b[1]) : !(b[1] <= a && a <= b[0]) }
            }, "null": { conditionName: function (a, b) { return a.i18n("searchBuilder.conditions.date.empty", b.conditions.date.empty) }, init: c.initNoValue, inputValue: function () { }, isInputValid: function () { return !0 }, search: function (a) { return null === a || void 0 === a || 0 === a.length } }, "!null": {
                conditionName: function (a, b) { return a.i18n("searchBuilder.conditions.date.notEmpty", b.conditions.date.notEmpty) },
                init: c.initNoValue, inputValue: function () { }, isInputValid: function () { return !0 }, search: function (a) { return !(null === a || void 0 === a || 0 === a.length) }
            }
        }; c.momentDateConditions = {
            "=": { conditionName: function (a, b) { return a.i18n("searchBuilder.conditions.date.equals", b.conditions.date.equals) }, init: c.initDate, inputValue: c.inputValueInput, isInputValid: c.isInputValidInput, search: function (a, b, d) { return (0, window.moment)(a, d.s.dateFormat).valueOf() === (0, window.moment)(b[0], d.s.dateFormat).valueOf() } }, "!=": {
                conditionName: function (a,
                    b) { return a.i18n("searchBuilder.conditions.date.not", b.conditions.date.not) }, init: c.initDate, inputValue: c.inputValueInput, isInputValid: c.isInputValidInput, search: function (a, b, d) { return (0, window.moment)(a, d.s.dateFormat).valueOf() !== (0, window.moment)(b[0], d.s.dateFormat).valueOf() }
            }, "<": {
                conditionName: function (a, b) { return a.i18n("searchBuilder.conditions.date.before", b.conditions.date.before) }, init: c.initDate, inputValue: c.inputValueInput, isInputValid: c.isInputValidInput, search: function (a, b, d) {
                    return (0, window.moment)(a,
                        d.s.dateFormat).valueOf() < (0, window.moment)(b[0], d.s.dateFormat).valueOf()
                }
            }, ">": { conditionName: function (a, b) { return a.i18n("searchBuilder.conditions.date.after", b.conditions.date.after) }, init: c.initDate, inputValue: c.inputValueInput, isInputValid: c.isInputValidInput, search: function (a, b, d) { return (0, window.moment)(a, d.s.dateFormat).valueOf() > (0, window.moment)(b[0], d.s.dateFormat).valueOf() } }, between: {
                conditionName: function (a, b) { return a.i18n("searchBuilder.conditions.date.between", b.conditions.date.between) },
                init: c.init2Date, inputValue: c.inputValueInput, isInputValid: c.isInputValidInput, search: function (a, b, d) { a = (0, window.moment)(a, d.s.dateFormat).valueOf(); var e = (0, window.moment)(b[0], d.s.dateFormat).valueOf(); b = (0, window.moment)(b[1], d.s.dateFormat).valueOf(); return e < b ? e <= a && a <= b : b <= a && a <= e }
            }, "!between": {
                conditionName: function (a, b) { return a.i18n("searchBuilder.conditions.date.notBetween", b.conditions.date.notBetween) }, init: c.init2Date, inputValue: c.inputValueInput, isInputValid: c.isInputValidInput, search: function (a,
                    b, d) { a = (0, window.moment)(a, d.s.dateFormat).valueOf(); var e = (0, window.moment)(b[0], d.s.dateFormat).valueOf(); b = (0, window.moment)(b[1], d.s.dateFormat).valueOf(); return e < b ? !(+e <= +a && +a <= +b) : !(+b <= +a && +a <= +e) }
            }, "null": { conditionName: function (a, b) { return a.i18n("searchBuilder.conditions.date.empty", b.conditions.date.empty) }, init: c.initNoValue, inputValue: function () { }, isInputValid: function () { return !0 }, search: function (a) { return null === a || void 0 === a || 0 === a.length } }, "!null": {
                conditionName: function (a, b) {
                    return a.i18n("searchBuilder.conditions.date.notEmpty",
                        b.conditions.date.notEmpty)
                }, init: c.initNoValue, inputValue: function () { }, isInputValid: function () { return !0 }, search: function (a) { return !(null === a || void 0 === a || 0 === a.length) }
            }
        }; c.luxonDateConditions = {
            "=": {
                conditionName: function (a, b) { return a.i18n("searchBuilder.conditions.date.equals", b.conditions.date.equals) }, init: c.initDate, inputValue: c.inputValueInput, isInputValid: c.isInputValidInput, search: function (a, b, d) {
                    return window.luxon.DateTime.fromFormat(a, d.s.dateFormat).ts === window.luxon.DateTime.fromFormat(b[0],
                        d.s.dateFormat).ts
                }
            }, "!=": { conditionName: function (a, b) { return a.i18n("searchBuilder.conditions.date.not", b.conditions.date.not) }, init: c.initDate, inputValue: c.inputValueInput, isInputValid: c.isInputValidInput, search: function (a, b, d) { return window.luxon.DateTime.fromFormat(a, d.s.dateFormat).ts !== window.luxon.DateTime.fromFormat(b[0], d.s.dateFormat).ts } }, "<": {
                conditionName: function (a, b) { return a.i18n("searchBuilder.conditions.date.before", b.conditions.date.before) }, init: c.initDate, inputValue: c.inputValueInput,
                isInputValid: c.isInputValidInput, search: function (a, b, d) { return window.luxon.DateTime.fromFormat(a, d.s.dateFormat).ts < window.luxon.DateTime.fromFormat(b[0], d.s.dateFormat).ts }
            }, ">": { conditionName: function (a, b) { return a.i18n("searchBuilder.conditions.date.after", b.conditions.date.after) }, init: c.initDate, inputValue: c.inputValueInput, isInputValid: c.isInputValidInput, search: function (a, b, d) { return window.luxon.DateTime.fromFormat(a, d.s.dateFormat).ts > window.luxon.DateTime.fromFormat(b[0], d.s.dateFormat).ts } },
            between: { conditionName: function (a, b) { return a.i18n("searchBuilder.conditions.date.between", b.conditions.date.between) }, init: c.init2Date, inputValue: c.inputValueInput, isInputValid: c.isInputValidInput, search: function (a, b, d) { a = window.luxon.DateTime.fromFormat(a, d.s.dateFormat).ts; var e = window.luxon.DateTime.fromFormat(b[0], d.s.dateFormat).ts; b = window.luxon.DateTime.fromFormat(b[1], d.s.dateFormat).ts; return e < b ? e <= a && a <= b : b <= a && a <= e } }, "!between": {
                conditionName: function (a, b) {
                    return a.i18n("searchBuilder.conditions.date.notBetween",
                        b.conditions.date.notBetween)
                }, init: c.init2Date, inputValue: c.inputValueInput, isInputValid: c.isInputValidInput, search: function (a, b, d) { a = window.luxon.DateTime.fromFormat(a, d.s.dateFormat).ts; var e = window.luxon.DateTime.fromFormat(b[0], d.s.dateFormat).ts; b = window.luxon.DateTime.fromFormat(b[1], d.s.dateFormat).ts; return e < b ? !(+e <= +a && +a <= +b) : !(+b <= +a && +a <= +e) }
            }, "null": {
                conditionName: function (a, b) { return a.i18n("searchBuilder.conditions.date.empty", b.conditions.date.empty) }, init: c.initNoValue, inputValue: function () { },
                isInputValid: function () { return !0 }, search: function (a) { return null === a || void 0 === a || 0 === a.length }
            }, "!null": { conditionName: function (a, b) { return a.i18n("searchBuilder.conditions.date.notEmpty", b.conditions.date.notEmpty) }, init: c.initNoValue, inputValue: function () { }, isInputValid: function () { return !0 }, search: function (a) { return !(null === a || void 0 === a || 0 === a.length) } }
        }; c.numConditions = {
            "=": {
                conditionName: function (a, b) { return a.i18n("searchBuilder.conditions.number.equals", b.conditions.number.equals) }, init: c.initSelect,
                inputValue: c.inputValueSelect, isInputValid: c.isInputValidSelect, search: function (a, b) { return +a === +b[0] }
            }, "!=": { conditionName: function (a, b) { return a.i18n("searchBuilder.conditions.number.not", b.conditions.number.not) }, init: c.initSelect, inputValue: c.inputValueSelect, isInputValid: c.isInputValidSelect, search: function (a, b) { return +a !== +b[0] } }, "<": {
                conditionName: function (a, b) { return a.i18n("searchBuilder.conditions.number.lt", b.conditions.number.lt) }, init: c.initInput, inputValue: c.inputValueInput, isInputValid: c.isInputValidInput,
                search: function (a, b) { return +a < +b[0] }
            }, "<=": { conditionName: function (a, b) { return a.i18n("searchBuilder.conditions.number.lte", b.conditions.number.lte) }, init: c.initInput, inputValue: c.inputValueInput, isInputValid: c.isInputValidInput, search: function (a, b) { return +a <= +b[0] } }, ">=": { conditionName: function (a, b) { return a.i18n("searchBuilder.conditions.number.gte", b.conditions.number.gte) }, init: c.initInput, inputValue: c.inputValueInput, isInputValid: c.isInputValidInput, search: function (a, b) { return +a >= +b[0] } }, ">": {
                conditionName: function (a,
                    b) { return a.i18n("searchBuilder.conditions.number.gt", b.conditions.number.gt) }, init: c.initInput, inputValue: c.inputValueInput, isInputValid: c.isInputValidInput, search: function (a, b) { return +a > +b[0] }
            }, between: { conditionName: function (a, b) { return a.i18n("searchBuilder.conditions.number.between", b.conditions.number.between) }, init: c.init2Input, inputValue: c.inputValueInput, isInputValid: c.isInputValidInput, search: function (a, b) { return +b[0] < +b[1] ? +b[0] <= +a && +a <= +b[1] : +b[1] <= +a && +a <= +b[0] } }, "!between": {
                conditionName: function (a,
                    b) { return a.i18n("searchBuilder.conditions.number.notBetween", b.conditions.number.notBetween) }, init: c.init2Input, inputValue: c.inputValueInput, isInputValid: c.isInputValidInput, search: function (a, b) { return +b[0] < +b[1] ? !(+b[0] <= +a && +a <= +b[1]) : !(+b[1] <= +a && +a <= +b[0]) }
            }, "null": {
                conditionName: function (a, b) { return a.i18n("searchBuilder.conditions.number.empty", b.conditions.number.empty) }, init: c.initNoValue, inputValue: function () { }, isInputValid: function () { return !0 }, search: function (a) {
                    return null === a || void 0 ===
                        a || 0 === a.length
                }
            }, "!null": { conditionName: function (a, b) { return a.i18n("searchBuilder.conditions.number.notEmpty", b.conditions.number.notEmpty) }, init: c.initNoValue, inputValue: function () { }, isInputValid: function () { return !0 }, search: function (a) { return !(null === a || void 0 === a || 0 === a.length) } }
        }; c.numFmtConditions = {
            "=": {
                conditionName: function (a, b) { return a.i18n("searchBuilder.conditions.number.equals", b.conditions.number.equals) }, init: c.initSelect, inputValue: c.inputValueSelect, isInputValid: c.isInputValidSelect,
                search: function (a, b) { return c.parseNumFmt(a) === c.parseNumFmt(b[0]) }
            }, "!=": { conditionName: function (a, b) { return a.i18n("searchBuilder.conditions.number.not", b.conditions.number.not) }, init: c.initSelect, inputValue: c.inputValueSelect, isInputValid: c.isInputValidSelect, search: function (a, b) { return c.parseNumFmt(a) !== c.parseNumFmt(b[0]) } }, "<": {
                conditionName: function (a, b) { return a.i18n("searchBuilder.conditions.number.lt", b.conditions.number.lt) }, init: c.initInput, inputValue: c.inputValueInput, isInputValid: c.isInputValidInput,
                search: function (a, b) { return c.parseNumFmt(a) < c.parseNumFmt(b[0]) }
            }, "<=": { conditionName: function (a, b) { return a.i18n("searchBuilder.conditions.number.lte", b.conditions.number.lte) }, init: c.initInput, inputValue: c.inputValueInput, isInputValid: c.isInputValidInput, search: function (a, b) { return c.parseNumFmt(a) <= c.parseNumFmt(b[0]) } }, ">=": {
                conditionName: function (a, b) { return a.i18n("searchBuilder.conditions.number.gte", b.conditions.number.gte) }, init: c.initInput, inputValue: c.inputValueInput, isInputValid: c.isInputValidInput,
                search: function (a, b) { return c.parseNumFmt(a) >= c.parseNumFmt(b[0]) }
            }, ">": { conditionName: function (a, b) { return a.i18n("searchBuilder.conditions.number.gt", b.conditions.number.gt) }, init: c.initInput, inputValue: c.inputValueInput, isInputValid: c.isInputValidInput, search: function (a, b) { return c.parseNumFmt(a) > c.parseNumFmt(b[0]) } }, between: {
                conditionName: function (a, b) { return a.i18n("searchBuilder.conditions.number.between", b.conditions.number.between) }, init: c.init2Input, inputValue: c.inputValueInput, isInputValid: c.isInputValidInput,
                search: function (a, b) { a = c.parseNumFmt(a); var d = c.parseNumFmt(b[0]); b = c.parseNumFmt(b[1]); return +d < +b ? +d <= +a && +a <= +b : +b <= +a && +a <= +d }
            }, "!between": { conditionName: function (a, b) { return a.i18n("searchBuilder.conditions.number.notBetween", b.conditions.number.notBetween) }, init: c.init2Input, inputValue: c.inputValueInput, isInputValid: c.isInputValidInput, search: function (a, b) { a = c.parseNumFmt(a); var d = c.parseNumFmt(b[0]); b = c.parseNumFmt(b[1]); return +d < +b ? !(+d <= +a && +a <= +b) : !(+b <= +a && +a <= +d) } }, "null": {
                conditionName: function (a,
                    b) { return a.i18n("searchBuilder.conditions.number.empty", b.conditions.number.empty) }, init: c.initNoValue, inputValue: function () { }, isInputValid: function () { return !0 }, search: function (a) { return null === a || void 0 === a || 0 === a.length }
            }, "!null": { conditionName: function (a, b) { return a.i18n("searchBuilder.conditions.number.notEmpty", b.conditions.number.notEmpty) }, init: c.initNoValue, inputValue: function () { }, isInputValid: function () { return !0 }, search: function (a) { return !(null === a || void 0 === a || 0 === a.length) } }
        }; c.stringConditions =
        {
            "=": { conditionName: function (a, b) { return a.i18n("searchBuilder.conditions.string.equals", b.conditions.string.equals) }, init: c.initSelect, inputValue: c.inputValueSelect, isInputValid: c.isInputValidSelect, search: function (a, b) { return a === b[0] } }, "!=": { conditionName: function (a, b) { return a.i18n("searchBuilder.conditions.string.not", b.conditions.string.not) }, init: c.initSelect, inputValue: c.inputValueSelect, isInputValid: c.isInputValidInput, search: function (a, b) { return a !== b[0] } }, starts: {
                conditionName: function (a,
                    b) { return a.i18n("searchBuilder.conditions.string.startsWith", b.conditions.string.startsWith) }, init: c.initInput, inputValue: c.inputValueInput, isInputValid: c.isInputValidInput, search: function (a, b) { return 0 === a.toLowerCase().indexOf(b[0].toLowerCase()) }
            }, "!starts": { conditionName: function (a, b) { return a.i18n("searchBuilder.conditions.string.notStartsWith", b.conditions.string.notStartsWith) }, init: c.initInput, inputValue: c.inputValueInput, isInputValid: c.isInputValidInput, search: function (a, b) { return 0 !== a.toLowerCase().indexOf(b[0].toLowerCase()) } },
            contains: { conditionName: function (a, b) { return a.i18n("searchBuilder.conditions.string.contains", b.conditions.string.contains) }, init: c.initInput, inputValue: c.inputValueInput, isInputValid: c.isInputValidInput, search: function (a, b) { return a.toLowerCase().includes(b[0].toLowerCase()) } }, "!contains": {
                conditionName: function (a, b) { return a.i18n("searchBuilder.conditions.string.notContains", b.conditions.string.notContains) }, init: c.initInput, inputValue: c.inputValueInput, isInputValid: c.isInputValidInput, search: function (a,
                    b) { return !a.toLowerCase().includes(b[0].toLowerCase()) }
            }, ends: { conditionName: function (a, b) { return a.i18n("searchBuilder.conditions.string.endsWith", b.conditions.string.endsWith) }, init: c.initInput, inputValue: c.inputValueInput, isInputValid: c.isInputValidInput, search: function (a, b) { return a.toLowerCase().endsWith(b[0].toLowerCase()) } }, "!ends": {
                conditionName: function (a, b) { return a.i18n("searchBuilder.conditions.string.notEndsWith", b.conditions.string.notEndsWith) }, init: c.initInput, inputValue: c.inputValueInput,
                isInputValid: c.isInputValidInput, search: function (a, b) { return !a.toLowerCase().endsWith(b[0].toLowerCase()) }
            }, "null": { conditionName: function (a, b) { return a.i18n("searchBuilder.conditions.string.empty", b.conditions.string.empty) }, init: c.initNoValue, inputValue: function () { }, isInputValid: function () { return !0 }, search: function (a) { return null === a || void 0 === a || 0 === a.length } }, "!null": {
                conditionName: function (a, b) { return a.i18n("searchBuilder.conditions.string.notEmpty", b.conditions.string.notEmpty) }, init: c.initNoValue,
                inputValue: function () { }, isInputValid: function () { return !0 }, search: function (a) { return !(null === a || void 0 === a || 0 === a.length) }
            }
        }; c.arrayConditions = {
            contains: { conditionName: function (a, b) { return a.i18n("searchBuilder.conditions.array.contains", b.conditions.array.contains) }, init: c.initSelectArray, inputValue: c.inputValueSelect, isInputValid: c.isInputValidSelect, search: function (a, b) { return a.includes(b[0]) } }, without: {
                conditionName: function (a, b) { return a.i18n("searchBuilder.conditions.array.without", b.conditions.array.without) },
                init: c.initSelectArray, inputValue: c.inputValueSelect, isInputValid: c.isInputValidSelect, search: function (a, b) { return -1 === a.indexOf(b[0]) }
            }, "=": { conditionName: function (a, b) { return a.i18n("searchBuilder.conditions.array.equals", b.conditions.array.equals) }, init: c.initSelect, inputValue: c.inputValueSelect, isInputValid: c.isInputValidSelect, search: function (a, b) { if (a.length === b[0].length) { for (var d = 0; d < a.length; d++)if (a[d] !== b[0][d]) return !1; return !0 } return !1 } }, "!=": {
                conditionName: function (a, b) {
                    return a.i18n("searchBuilder.conditions.array.not",
                        b.conditions.array.not)
                }, init: c.initSelect, inputValue: c.inputValueSelect, isInputValid: c.isInputValidSelect, search: function (a, b) { if (a.length === b[0].length) { for (var d = 0; d < a.length; d++)if (a[d] !== b[0][d]) return !0; return !1 } return !0 }
            }, "null": { conditionName: function (a, b) { return a.i18n("searchBuilder.conditions.array.empty", b.conditions.array.empty) }, init: c.initNoValue, inputValue: function () { }, isInputValid: function () { return !0 }, search: function (a) { return null === a || void 0 === a || 0 === a.length } }, "!null": {
                conditionName: function (a,
                    b) { return a.i18n("searchBuilder.conditions.array.notEmpty", b.conditions.array.notEmpty) }, init: c.initNoValue, inputValue: function () { }, isInputValid: function () { return !0 }, search: function (a) { return null !== a && void 0 !== a && 0 !== a.length }
            }
        }; c.defaults = {
            columns: !0, conditions: {
                array: c.arrayConditions, date: c.dateConditions, html: c.stringConditions, "html-num": c.numConditions, "html-num-fmt": c.numFmtConditions, luxon: c.luxonDateConditions, moment: c.momentDateConditions, num: c.numConditions, "num-fmt": c.numFmtConditions,
                string: c.stringConditions
            }, depthLimit: !1, enterSearch: !1, filterChanged: void 0, greyscale: !1, i18n: { add: "Add Condition", button: { 0: "Search Builder", _: "Search Builder (%d)" }, clearAll: "Clear All", condition: "Condition", data: "Data", "delete": "&times", deleteTitle: "Delete filtering rule", left: "<", leftTitle: "Outdent criteria", logicAnd: "And", logicOr: "Or", right: ">", rightTitle: "Indent criteria", title: { 0: "Custom Search Builder", _: "Custom Search Builder (%d)" }, value: "Value", valueJoiner: "and" }, logic: "AND", orthogonal: {
                display: "display",
                search: "filter"
            }, preDefined: !1
        }; return c
    }(), v, C, E = function () {
        function c(a, b, d, e, f, g, l) {
            void 0 === e && (e = 0); void 0 === f && (f = !1); void 0 === g && (g = 1); void 0 === l && (l = void 0); if (!C || !C.versionCheck || !C.versionCheck("1.10.0")) throw Error("SearchBuilder requires DataTables 1.10 or newer"); this.classes = v.extend(!0, {}, c.classes); this.c = v.extend(!0, {}, c.defaults, b); this.s = { criteria: [], depth: g, dt: a, index: e, isChild: f, logic: void 0, opts: b, preventRedraw: !1, serverData: l, toDrop: void 0, topGroup: d }; this.dom = {
                add: v("<button/>").addClass(this.classes.add).addClass(this.classes.button).attr("type",
                    "button"), clear: v("<button>&times</button>").addClass(this.classes.button).addClass(this.classes.clearGroup).attr("type", "button"), container: v("<div/>").addClass(this.classes.group), logic: v("<button><div/></button>").addClass(this.classes.logic).addClass(this.classes.button).attr("type", "button"), logicContainer: v("<div/>").addClass(this.classes.logicContainer)
            }; void 0 === this.s.topGroup && (this.s.topGroup = this.dom.container); this._setup(); return this
        } c.prototype.destroy = function () {
            this.dom.add.off(".dtsb");
            this.dom.logic.off(".dtsb"); this.dom.container.trigger("dtsb-destroy").remove(); this.s.criteria = []
        }; c.prototype.getDetails = function (a) { void 0 === a && (a = !1); if (0 === this.s.criteria.length) return {}; for (var b = { criteria: [], logic: this.s.logic }, d = 0, e = this.s.criteria; d < e.length; d++)b.criteria.push(e[d].criteria.getDetails(a)); return b }; c.prototype.getNode = function () { return this.dom.container }; c.prototype.rebuild = function (a) {
            if (!(void 0 === a.criteria || null === a.criteria || Array.isArray(a.criteria) && 0 === a.criteria.length)) {
                this.s.logic =
                a.logic; this.dom.logic.children().first().html("OR" === this.s.logic ? this.s.dt.i18n("searchBuilder.logicOr", this.c.i18n.logicOr) : this.s.dt.i18n("searchBuilder.logicAnd", this.c.i18n.logicAnd)); if (Array.isArray(a.criteria)) for (var b = 0, d = a.criteria; b < d.length; b++)a = d[b], void 0 !== a.logic ? this._addPrevGroup(a) : void 0 === a.logic && this._addPrevCriteria(a); b = 0; for (d = this.s.criteria; b < d.length; b++)a = d[b], a.criteria instanceof q && (a.criteria.updateArrows(1 < this.s.criteria.length), this._setCriteriaListeners(a.criteria))
            }
        };
        c.prototype.redrawContents = function () {
            if (!this.s.preventRedraw) {
                this.dom.container.children().detach(); this.dom.container.append(this.dom.logicContainer).append(this.dom.add); this.s.criteria.sort(function (d, e) { return d.criteria.s.index < e.criteria.s.index ? -1 : d.criteria.s.index > e.criteria.s.index ? 1 : 0 }); this.setListeners(); for (var a = 0; a < this.s.criteria.length; a++) {
                    var b = this.s.criteria[a].criteria; b instanceof q ? (this.s.criteria[a].index = a, this.s.criteria[a].criteria.s.index = a, this.s.criteria[a].criteria.dom.container.insertBefore(this.dom.add),
                        this._setCriteriaListeners(b), this.s.criteria[a].criteria.s.preventRedraw = this.s.preventRedraw, this.s.criteria[a].criteria.rebuild(this.s.criteria[a].criteria.getDetails()), this.s.criteria[a].criteria.s.preventRedraw = !1) : b instanceof c && 0 < b.s.criteria.length ? (this.s.criteria[a].index = a, this.s.criteria[a].criteria.s.index = a, this.s.criteria[a].criteria.dom.container.insertBefore(this.dom.add), b.s.preventRedraw = this.s.preventRedraw, b.redrawContents(), b.s.preventRedraw = !1, this._setGroupListeners(b)) :
                        (this.s.criteria.splice(a, 1), a--)
                } this.setupLogic()
            }
        }; c.prototype.redrawLogic = function () { for (var a = 0, b = this.s.criteria; a < b.length; a++) { var d = b[a]; d.criteria instanceof c && d.criteria.redrawLogic() } this.setupLogic() }; c.prototype.search = function (a, b) { return "AND" === this.s.logic ? this._andSearch(a, b) : "OR" === this.s.logic ? this._orSearch(a, b) : !0 }; c.prototype.setupLogic = function () {
            this.dom.logicContainer.remove(); this.dom.clear.remove(); if (1 > this.s.criteria.length) this.s.isChild || (this.dom.container.trigger("dtsb-destroy"),
                this.dom.container.css("margin-left", 0)); else {
                    this.dom.clear.height("0px"); this.dom.logicContainer.append(this.dom.clear); this.dom.container.prepend(this.dom.logicContainer); for (var a = 0, b = this.s.criteria; a < b.length; a++) { var d = b[a]; d.criteria instanceof q && d.criteria.setupButtons() } a = this.dom.container.outerHeight() - 1; this.dom.logicContainer.width(a); this._setLogicListener(); this.dom.container.css("margin-left", this.dom.logicContainer.outerHeight(!0)); a = this.dom.logicContainer.offset(); b = a.left; d =
                        this.dom.container.offset().left; b = b - (b - d) - this.dom.logicContainer.outerHeight(!0); this.dom.logicContainer.offset({ left: b }); b = this.dom.logicContainer.next(); a = a.top; b = v(b).offset().top; this.dom.logicContainer.offset({ top: a - (a - b) }); this.dom.clear.outerHeight(this.dom.logicContainer.height()); this._setClearListener()
            }
        }; c.prototype.setListeners = function () {
            var a = this; this.dom.add.unbind("click"); this.dom.add.on("click.dtsb", function () {
                a.s.isChild || a.dom.container.prepend(a.dom.logicContainer); a.addCriteria();
                a.dom.container.trigger("dtsb-add"); a.s.dt.state.save(); return !1
            }); for (var b = 0, d = this.s.criteria; b < d.length; b++)d[b].criteria.setListeners(); this._setClearListener(); this._setLogicListener()
        }; c.prototype.addCriteria = function (a) {
            void 0 === a && (a = null); var b = null === a ? this.s.criteria.length : a.s.index, d = new q(this.s.dt, this.s.opts, this.s.topGroup, b, this.s.depth, this.s.serverData); null !== a && (d.c = a.c, d.s = a.s, d.s.depth = this.s.depth, d.classes = a.classes); d.populate(); a = !1; for (var e = 0; e < this.s.criteria.length; e++)0 ===
                e && this.s.criteria[e].criteria.s.index > d.s.index ? (d.getNode().insertBefore(this.s.criteria[e].criteria.dom.container), a = !0) : e < this.s.criteria.length - 1 && this.s.criteria[e].criteria.s.index < d.s.index && this.s.criteria[e + 1].criteria.s.index > d.s.index && (d.getNode().insertAfter(this.s.criteria[e].criteria.dom.container), a = !0); a || d.getNode().insertBefore(this.dom.add); this.s.criteria.push({ criteria: d, index: b }); this.s.criteria = this.s.criteria.sort(function (f, g) { return f.criteria.s.index - g.criteria.s.index });
            b = 0; for (a = this.s.criteria; b < a.length; b++)e = a[b], e.criteria instanceof q && e.criteria.updateArrows(1 < this.s.criteria.length); this._setCriteriaListeners(d); d.setListeners(); this.setupLogic()
        }; c.prototype.checkFilled = function () { for (var a = 0, b = this.s.criteria; a < b.length; a++) { var d = b[a]; if (d.criteria instanceof q && d.criteria.s.filled || d.criteria instanceof c && d.criteria.checkFilled()) return !0 } return !1 }; c.prototype.count = function () {
            for (var a = 0, b = 0, d = this.s.criteria; b < d.length; b++) {
                var e = d[b]; e.criteria instanceof
                    c ? a += e.criteria.count() : a++
            } return a
        }; c.prototype._addPrevGroup = function (a) { var b = this.s.criteria.length, d = new c(this.s.dt, this.c, this.s.topGroup, b, !0, this.s.depth + 1, this.s.serverData); this.s.criteria.push({ criteria: d, index: b, logic: d.s.logic }); d.rebuild(a); this.s.criteria[b].criteria = d; this.s.topGroup.trigger("dtsb-redrawContents"); this._setGroupListeners(d) }; c.prototype._addPrevCriteria = function (a) {
            var b = this.s.criteria.length, d = new q(this.s.dt, this.s.opts, this.s.topGroup, b, this.s.depth, this.s.serverData);
            d.populate(); this.s.criteria.push({ criteria: d, index: b }); d.s.preventRedraw = this.s.preventRedraw; d.rebuild(a); d.s.preventRedraw = !1; this.s.criteria[b].criteria = d; this.s.preventRedraw || this.s.topGroup.trigger("dtsb-redrawContents")
        }; c.prototype._andSearch = function (a, b) { if (0 === this.s.criteria.length) return !0; for (var d = 0, e = this.s.criteria; d < e.length; d++) { var f = e[d]; if (!(f.criteria instanceof q && !f.criteria.s.filled || f.criteria.search(a, b))) return !1 } return !0 }; c.prototype._orSearch = function (a, b) {
            if (0 === this.s.criteria.length) return !0;
            for (var d = !1, e = 0, f = this.s.criteria; e < f.length; e++) { var g = f[e]; if (g.criteria instanceof q && g.criteria.s.filled) { if (d = !0, g.criteria.search(a, b)) return !0 } else if (g.criteria instanceof c && g.criteria.checkFilled() && (d = !0, g.criteria.search(a, b))) return !0 } return !d
        }; c.prototype._removeCriteria = function (a, b) {
            void 0 === b && (b = !1); if (1 >= this.s.criteria.length && this.s.isChild) this.destroy(); else {
                for (var d = void 0, e = 0; e < this.s.criteria.length; e++)this.s.criteria[e].index === a.s.index && (!b || this.s.criteria[e].criteria instanceof
                    c) && (d = e); void 0 !== d && this.s.criteria.splice(d, 1); for (e = 0; e < this.s.criteria.length; e++)this.s.criteria[e].index = e, this.s.criteria[e].criteria.s.index = e
            }
        }; c.prototype._setCriteriaListeners = function (a) {
            var b = this; a.dom["delete"].unbind("click").on("click.dtsb", function () {
                b._removeCriteria(a); a.dom.container.remove(); for (var d = 0, e = b.s.criteria; d < e.length; d++) { var f = e[d]; f.criteria instanceof q && f.criteria.updateArrows(1 < b.s.criteria.length) } a.destroy(); b.s.dt.draw(); b.s.topGroup.trigger("dtsb-redrawContents");
                return !1
            }); a.dom.right.unbind("click").on("click.dtsb", function () { var d = a.s.index, e = new c(b.s.dt, b.s.opts, b.s.topGroup, a.s.index, !0, b.s.depth + 1, b.s.serverData); e.addCriteria(a); b.s.criteria[d].criteria = e; b.s.criteria[d].logic = "AND"; b.s.topGroup.trigger("dtsb-redrawContents"); b._setGroupListeners(e); return !1 }); a.dom.left.unbind("click").on("click.dtsb", function () {
                b.s.toDrop = new q(b.s.dt, b.s.opts, b.s.topGroup, a.s.index, void 0, b.s.serverData); b.s.toDrop.s = a.s; b.s.toDrop.c = a.c; b.s.toDrop.classes = a.classes;
                b.s.toDrop.populate(); var d = b.s.toDrop.s.index; b.dom.container.trigger("dtsb-dropCriteria"); a.s.index = d; b._removeCriteria(a); b.s.topGroup.trigger("dtsb-redrawContents"); b.s.dt.draw(); return !1
            })
        }; c.prototype._setClearListener = function () { var a = this; this.dom.clear.unbind("click").on("click.dtsb", function () { if (!a.s.isChild) return a.dom.container.trigger("dtsb-clearContents"), !1; a.destroy(); a.s.topGroup.trigger("dtsb-redrawContents"); return !1 }) }; c.prototype._setGroupListeners = function (a) {
            var b = this; a.dom.add.unbind("click").on("click.dtsb",
                function () { b.setupLogic(); b.dom.container.trigger("dtsb-add"); return !1 }); a.dom.container.unbind("dtsb-add").on("dtsb-add.dtsb", function () { b.setupLogic(); b.dom.container.trigger("dtsb-add"); return !1 }); a.dom.container.unbind("dtsb-destroy").on("dtsb-destroy.dtsb", function () { b._removeCriteria(a, !0); a.dom.container.remove(); b.setupLogic(); return !1 }); a.dom.container.unbind("dtsb-dropCriteria").on("dtsb-dropCriteria.dtsb", function () {
                    var d = a.s.toDrop; d.s.index = a.s.index; d.updateArrows(1 < b.s.criteria.length);
                    b.addCriteria(d); return !1
                }); a.setListeners()
        }; c.prototype._setup = function () {
            this.setListeners(); this.dom.add.html(this.s.dt.i18n("searchBuilder.add", this.c.i18n.add)); this.dom.logic.children().first().html("OR" === this.c.logic ? this.s.dt.i18n("searchBuilder.logicOr", this.c.i18n.logicOr) : this.s.dt.i18n("searchBuilder.logicAnd", this.c.i18n.logicAnd)); this.s.logic = "OR" === this.c.logic ? "OR" : "AND"; this.c.greyscale && this.dom.logic.addClass(this.classes.greyscale); this.dom.logicContainer.append(this.dom.logic).append(this.dom.clear);
            this.s.isChild && this.dom.container.append(this.dom.logicContainer); this.dom.container.append(this.dom.add)
        }; c.prototype._setLogicListener = function () { var a = this; this.dom.logic.unbind("click").on("click.dtsb", function () { a._toggleLogic(); a.s.dt.draw(); for (var b = 0, d = a.s.criteria; b < d.length; b++)d[b].criteria.setListeners() }) }; c.prototype._toggleLogic = function () {
            "OR" === this.s.logic ? (this.s.logic = "AND", this.dom.logic.children().first().html(this.s.dt.i18n("searchBuilder.logicAnd", this.c.i18n.logicAnd))) :
            "AND" === this.s.logic && (this.s.logic = "OR", this.dom.logic.children().first().html(this.s.dt.i18n("searchBuilder.logicOr", this.c.i18n.logicOr)))
        }; c.version = "1.1.0"; c.classes = { add: "dtsb-add", button: "dtsb-button", clearGroup: "dtsb-clearGroup", greyscale: "dtsb-greyscale", group: "dtsb-group", inputButton: "dtsb-iptbtn", logic: "dtsb-logic", logicContainer: "dtsb-logicContainer" }; c.defaults = {
            columns: !0, conditions: {
                date: q.dateConditions, html: q.stringConditions, "html-num": q.numConditions, "html-num-fmt": q.numFmtConditions,
                luxon: q.luxonDateConditions, moment: q.momentDateConditions, num: q.numConditions, "num-fmt": q.numFmtConditions, string: q.stringConditions
            }, depthLimit: !1, enterSearch: !1, filterChanged: void 0, greyscale: !1, i18n: {
                add: "Add Condition", button: { 0: "Search Builder", _: "Search Builder (%d)" }, clearAll: "Clear All", condition: "Condition", data: "Data", "delete": "&times", deleteTitle: "Delete filtering rule", left: "<", leftTitle: "Outdent criteria", logicAnd: "And", logicOr: "Or", right: ">", rightTitle: "Indent criteria", title: {
                    0: "Custom Search Builder",
                    _: "Custom Search Builder (%d)"
                }, value: "Value", valueJoiner: "and"
            }, logic: "AND", orthogonal: { display: "display", search: "filter" }, preDefined: !1
        }; return c
    }(), w, B, G = function () {
        function c(a, b) {
            var d = this; if (!B || !B.versionCheck || !B.versionCheck("1.10.0")) throw Error("SearchBuilder requires DataTables 1.10 or newer"); a = new B.Api(a); this.classes = w.extend(!0, {}, c.classes); this.c = w.extend(!0, {}, c.defaults, b); this.dom = {
                clearAll: w('<button type="button">' + a.i18n("searchBuilder.clearAll", this.c.i18n.clearAll) + "</button>").addClass(this.classes.clearAll).addClass(this.classes.button).attr("type",
                    "button"), container: w("<div/>").addClass(this.classes.container), title: w("<div/>").addClass(this.classes.title), titleRow: w("<div/>").addClass(this.classes.titleRow), topGroup: void 0
            }; this.s = { dt: a, opts: b, search: void 0, serverData: void 0, topGroup: void 0 }; if (void 0 === a.settings()[0]._searchBuilder) {
                a.settings()[0]._searchBuilder = this; this.s.dt.page.info().serverSide && (this.s.dt.on("preXhr.dtsb", function (e, f, g) { (e = d.s.dt.state.loaded()) && e.searchBuilder && (g.searchBuilder = d._collapseArray(e.searchBuilder)) }),
                    this.s.dt.on("xhr.dtsb", function (e, f, g) { g && g.searchBuilder && g.searchBuilder.options && (d.s.serverData = g.searchBuilder.options) })); if (this.s.dt.settings()[0]._bInitComplete) this._setUp(); else a.one("init.dt", function () { d._setUp() }); return this
            }
        } c.prototype.getDetails = function (a) { void 0 === a && (a = !1); return this.s.topGroup.getDetails(a) }; c.prototype.getNode = function () { return this.dom.container }; c.prototype.rebuild = function (a) {
            this.dom.clearAll.click(); if (void 0 === a || null === a) return this; this.s.topGroup.s.preventRedraw =
                !0; this.s.topGroup.rebuild(a); this.s.topGroup.s.preventRedraw = !1; this._checkClear(); this._updateTitle(this.s.topGroup.count()); this.s.topGroup.redrawContents(); this.s.dt.draw(!1); this.s.topGroup.setListeners(); return this
        }; c.prototype._applyPreDefDefaults = function (a) {
            var b = this; void 0 !== a.criteria && void 0 === a.logic && (a.logic = "AND"); for (var d = function (l) {
                void 0 !== l.criteria ? l = e._applyPreDefDefaults(l) : e.s.dt.columns().every(function (p) {
                    b.s.dt.settings()[0].aoColumns[p].sTitle === l.data && (l.dataIdx =
                        p)
                })
            }, e = this, f = 0, g = a.criteria; f < g.length; f++)d(g[f]); return a
        }; c.prototype._setUp = function (a) {
            var b = this; void 0 === a && (a = !0); w.fn.DataTable.Api.registerPlural("columns().type()", "column().type()", function () { return this.iterator("column", function (l, p) { return l.aoColumns[p].sType }, 1) }); if (!B.DateTime) {
                var d = this.s.dt.columns().type().toArray(); if (void 0 === d || d.includes(void 0) || d.includes(null)) {
                    d = []; for (var e = 0, f = this.s.dt.settings()[0].aoColumns; e < f.length; e++) {
                        var g = f[e]; d.push(void 0 !== g.searchBuilderType ?
                            g.searchBuilderType : g.sType)
                    }
                } e = this.s.dt.columns().toArray(); if (void 0 === d || d.includes(void 0) || d.includes(null)) w.fn.dataTable.ext.oApi._fnColumnTypes(this.s.dt.settings()[0]), d = this.s.dt.columns().type().toArray(); for (f = 0; f < e[0].length; f++)if (g = d[e[0][f]], (!0 === this.c.columns || Array.isArray(this.c.columns) && this.c.columns.includes(f)) && (g.includes("date") || g.includes("moment") || g.includes("luxon"))) throw alert("SearchBuilder Requires DateTime when used with dates."), Error("SearchBuilder requires DateTime");
            } this.s.topGroup = new E(this.s.dt, this.c, void 0, void 0, void 0, void 0, this.s.serverData); this._setClearListener(); this.s.dt.on("stateSaveParams.dtsb", function (l, p, t) { t.searchBuilder = b.getDetails(); t.scroller ? t.start = b.s.dt.state().start : t.page = b.s.dt.page() }); this.s.dt.on("stateLoadParams.dtsb", function (l, p, t) { b.rebuild(t.searchBuilder) }); this._build(); this.s.dt.on("preXhr.dtsb", function (l, p, t) { b.s.dt.page.info().serverSide && (t.searchBuilder = b._collapseArray(b.getDetails(!0))) }); this.s.dt.on("column-reorder",
                function () { b.rebuild(b.getDetails()) }); a && (a = this.s.dt.state.loaded(), null !== a && void 0 !== a.searchBuilder ? (this.s.topGroup.rebuild(a.searchBuilder), this.s.topGroup.dom.container.trigger("dtsb-redrawContents"), this.s.dt.page.info().serverSide || (a.page ? this.s.dt.page(a.page).draw("page") : this.s.dt.scroller && a.scroller && this.s.dt.scroller().scrollToRow(a.scroller.topRow)), this.s.topGroup.setListeners()) : !1 !== this.c.preDefined && (this.c.preDefined = this._applyPreDefDefaults(this.c.preDefined), this.rebuild(this.c.preDefined)));
            this._setEmptyListener(); this.s.dt.state.save()
        }; c.prototype._collapseArray = function (a) { if (void 0 === a.logic) void 0 !== a.value && (a.value.sort(function (d, e) { isNaN(+d) || (d = +d, e = +e); return d < e ? -1 : e < d ? 1 : 0 }), a.value1 = a.value[0], a.value2 = a.value[1]); else for (var b = 0; b < a.criteria.length; b++)a.criteria[b] = this._collapseArray(a.criteria[b]); return a }; c.prototype._updateTitle = function (a) { this.dom.title.html(this.s.dt.i18n("searchBuilder.title", this.c.i18n.title, a)) }; c.prototype._build = function () {
            var a = this; this.dom.clearAll.remove();
            this.dom.container.empty(); var b = this.s.topGroup.count(); this._updateTitle(b); this.dom.titleRow.append(this.dom.title); this.dom.container.append(this.dom.titleRow); this.dom.topGroup = this.s.topGroup.getNode(); this.dom.container.append(this.dom.topGroup); this._setRedrawListener(); var d = this.s.dt.table(0).node(); w.fn.dataTable.ext.search.includes(this.s.search) || (this.s.search = function (e, f, g) { return e.nTable !== d ? !0 : a.s.topGroup.search(f, g) }, w.fn.dataTable.ext.search.push(this.s.search)); this.s.dt.on("destroy.dtsb",
                function () { a.dom.container.remove(); a.dom.clearAll.remove(); for (var e = w.fn.dataTable.ext.search.indexOf(a.s.search); -1 !== e;)w.fn.dataTable.ext.search.splice(e, 1), e = w.fn.dataTable.ext.search.indexOf(a.s.search); a.s.dt.off(".dtsb"); w(a.s.dt.table().node()).off(".dtsb") })
        }; c.prototype._checkClear = function () { 0 < this.s.topGroup.s.criteria.length ? (this.dom.clearAll.insertAfter(this.dom.title), this._setClearListener()) : this.dom.clearAll.remove() }; c.prototype._filterChanged = function (a) {
            var b = this.c.filterChanged;
            "function" === typeof b && b(a, this.s.dt.i18n("searchBuilder.button", this.c.i18n.button, a))
        }; c.prototype._setClearListener = function () { var a = this; this.dom.clearAll.unbind("click"); this.dom.clearAll.on("click.dtsb", function () { a.s.topGroup = new E(a.s.dt, a.c, void 0, void 0, void 0, void 0, a.s.serverData); a._build(); a.s.dt.draw(); a.s.topGroup.setListeners(); a.dom.clearAll.remove(); a._setEmptyListener(); a._filterChanged(0); return !1 }) }; c.prototype._setRedrawListener = function () {
            var a = this; this.s.topGroup.dom.container.unbind("dtsb-redrawContents");
            this.s.topGroup.dom.container.on("dtsb-redrawContents.dtsb", function () { a._checkClear(); a.s.topGroup.redrawContents(); a.s.topGroup.setupLogic(); a._setEmptyListener(); var b = a.s.topGroup.count(); a._updateTitle(b); a._filterChanged(b); a.s.dt.page.info().serverSide || a.s.dt.draw(); a.s.dt.state.save() }); this.s.topGroup.dom.container.unbind("dtsb-redrawContents-noDraw"); this.s.topGroup.dom.container.on("dtsb-redrawContents-noDraw.dtsb", function () {
                a._checkClear(); a.s.topGroup.s.preventRedraw = !0; a.s.topGroup.redrawContents();
                a.s.topGroup.s.preventRedraw = !1; a.s.topGroup.setupLogic(); a._setEmptyListener(); var b = a.s.topGroup.count(); a._updateTitle(b); a._filterChanged(b)
            }); this.s.topGroup.dom.container.unbind("dtsb-redrawLogic"); this.s.topGroup.dom.container.on("dtsb-redrawLogic.dtsb", function () { a.s.topGroup.redrawLogic(); var b = a.s.topGroup.count(); a._updateTitle(b); a._filterChanged(b) }); this.s.topGroup.dom.container.unbind("dtsb-add"); this.s.topGroup.dom.container.on("dtsb-add.dtsb", function () {
                var b = a.s.topGroup.count();
                a._updateTitle(b); a._filterChanged(b)
            }); this.s.dt.on("postEdit.dtsb postCreate.dtsb postRemove.dtsb", function () { a.s.topGroup.redrawContents() }); this.s.topGroup.dom.container.unbind("dtsb-clearContents"); this.s.topGroup.dom.container.on("dtsb-clearContents.dtsb", function () { a._setUp(!1); a._filterChanged(0); a.s.dt.draw() })
        }; c.prototype._setEmptyListener = function () { var a = this; this.s.topGroup.dom.add.on("click.dtsb", function () { a._checkClear() }); this.s.topGroup.dom.container.on("dtsb-destroy.dtsb", function () { a.dom.clearAll.remove() }) };
        c.version = "1.3.4"; c.classes = { button: "dtsb-button", clearAll: "dtsb-clearAll", container: "dtsb-searchBuilder", inputButton: "dtsb-iptbtn", title: "dtsb-title", titleRow: "dtsb-titleRow" }; c.defaults = {
            columns: !0, conditions: { date: q.dateConditions, html: q.stringConditions, "html-num": q.numConditions, "html-num-fmt": q.numFmtConditions, luxon: q.luxonDateConditions, moment: q.momentDateConditions, num: q.numConditions, "num-fmt": q.numFmtConditions, string: q.stringConditions }, depthLimit: !1, enterSearch: !1, filterChanged: void 0,
            greyscale: !1, i18n: {
                add: "Add Condition", button: { 0: "Search Builder", _: "Search Builder (%d)" }, clearAll: "Clear All", condition: "Condition", conditions: {
                    array: { contains: "Contains", empty: "Empty", equals: "Equals", not: "Not", notEmpty: "Not Empty", without: "Without" }, date: { after: "After", before: "Before", between: "Between", empty: "Empty", equals: "Equals", not: "Not", notBetween: "Not Between", notEmpty: "Not Empty" }, number: {
                        between: "Between", empty: "Empty", equals: "Equals", gt: "Greater Than", gte: "Greater Than Equal To", lt: "Less Than",
                        lte: "Less Than Equal To", not: "Not", notBetween: "Not Between", notEmpty: "Not Empty"
                    }, string: { contains: "Contains", empty: "Empty", endsWith: "Ends With", equals: "Equals", not: "Not", notContains: "Does Not Contain", notEmpty: "Not Empty", notEndsWith: "Does Not End With", notStartsWith: "Does Not Start With", startsWith: "Starts With" }
                }, data: "Data", "delete": "&times", deleteTitle: "Delete filtering rule", left: "<", leftTitle: "Outdent criteria", logicAnd: "And", logicOr: "Or", right: ">", rightTitle: "Indent criteria", title: {
                    0: "Custom Search Builder",
                    _: "Custom Search Builder (%d)"
                }, value: "Value", valueJoiner: "and"
            }, logic: "AND", orthogonal: { display: "display", search: "filter" }, preDefined: !1
        }; return c
    }(); (function (c) { "function" === typeof define && define.amd ? define(["jquery", "datatables.net"], function (a) { return c(a, window, document) }) : "object" === typeof exports ? module.exports = function (a, b) { a || (a = window); b && b.fn.dataTable || (b = require("datatables.net")(a, b).$); return c(b, a, a.document) } : c(window.jQuery, window, document) })(function (c, a, b) {
        function d(f, g) {
            f = new e.Api(f);
            g = g ? g : f.init().searchBuilder || e.defaults.searchBuilder; return (new G(f, g)).getNode()
        } m(c); n(c); k(c); var e = c.fn.dataTable; c.fn.dataTable.SearchBuilder = G; c.fn.DataTable.SearchBuilder = G; c.fn.dataTable.Group = E; c.fn.DataTable.Group = E; c.fn.dataTable.Criteria = q; c.fn.DataTable.Criteria = q; a = c.fn.dataTable.Api.register; c.fn.dataTable.ext.searchBuilder = { conditions: {} }; c.fn.dataTable.ext.buttons.searchBuilder = {
            action: function (f, g, l, p) {
                this.popover(p._searchBuilder.getNode(), { align: "container", span: "container" });
                f = p._searchBuilder.s.topGroup; void 0 !== f && f.dom.container.trigger("dtsb-redrawContents-noDraw"); 0 === f.s.criteria.length && c("." + c.fn.dataTable.Group.classes.add.replace(/ /g, ".")).click()
            }, config: {}, init: function (f, g, l) { var p = new c.fn.dataTable.SearchBuilder(f, c.extend({ filterChanged: function (t, A) { f.button(g).text(A) } }, l.config)); f.button(g).text(l.text || f.i18n("searchBuilder.button", p.c.i18n.button, 0)); l._searchBuilder = p }, text: null
        }; a("searchBuilder.getDetails()", function (f) {
            void 0 === f && (f = !1); var g =
                this.context[0]; return g._searchBuilder ? g._searchBuilder.getDetails(f) : null
        }); a("searchBuilder.rebuild()", function (f) { var g = this.context[0]; if (void 0 === g._searchBuilder) return null; g._searchBuilder.rebuild(f); return this }); a("searchBuilder.container()", function () { var f = this.context[0]; return f._searchBuilder ? f._searchBuilder.getNode() : null }); c(b).on("preInit.dt.dtsp", function (f, g) { "dt" === f.namespace && (g.oInit.searchBuilder || e.defaults.searchBuilder) && (g._searchBuilder || d(g)) }); e.ext.feature.push({
            cFeature: "Q",
            fnInit: d
        }); e.ext.features && e.ext.features.register("searchBuilder", d)
    })
})();