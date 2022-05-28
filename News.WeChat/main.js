import App from './App'
import Vue from 'vue'
Vue.use(uView);
// #ifndef VUE3

import uView from "uview-ui";
import store from './store';

Vue.use(store);
Vue.config.productionTip = false
App.mpType = 'app'
const app = new Vue({
	store,
    ...App
})
app.$mount()
// #endif

// #ifdef VUE3
import { createSSRApp } from 'vue'
export function createApp() {
  const app = createSSRApp(App)
  return {
    app
	
  }
}

// #endif