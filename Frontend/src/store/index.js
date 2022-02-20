import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

const store = new Vuex.Store({
	state: {
		/* User */
		userName: null,
		userEmail: null,
		userAvatar: null,

		/* NavBar */
		isNavBarVisible: true,

		/* FooterBar */
		isFooterBarVisible: true,

		/* Aside */
		isAsideVisible: true,
		isAsideMobileExpanded: false,

		/* Sample data (commonly used) */
		clients: [],
		bouquets: [],
		bouquetMessages: [],
		customers: [],
		recipients: [],

	},
	mutations: {
		/* A fit-them-all commit */
		basic(state,payload) {
			state[payload.key] = payload.value
		},

		/* User */
		user(state,payload) {
			if (payload.name) {
				state.userName = payload.name
			}
			if (payload.email) {
				state.userEmail = payload.email
			}
			if (payload.avatar) {
				state.userAvatar = payload.avatar
			}
		},

		/* Aside Mobile */
		asideMobileStateToggle(state,payload = null) {
			const htmlClassName = 'has-aside-mobile-expanded'

			let isShow

			if (payload !== null) {
				isShow = payload
			} else {
				isShow = !state.isAsideMobileExpanded
			}

			if (isShow) {
				document.documentElement.classList.add(htmlClassName)
			} else {
				document.documentElement.classList.remove(htmlClassName)
			}

			state.isAsideMobileExpanded = isShow
		},

		/* Full Page mode */
		fullPage(state,payload) {
			state.isNavBarVisible = !payload
			state.isAsideVisible = !payload
			state.isFooterBarVisible = !payload
		}
	},
	actions: {
		asideDesktopOnlyToggle(store,payload = null) {
			let method

			switch (payload) {
				case true:
					method = 'add'
					break
				case false:
					method = 'remove'
					break
				default:
					method = 'toggle'
			}
			document.documentElement.classList[method]('has-aside-desktop-only-visible')
		},
		toggleFullPage({ commit },payload) {
			commit('fullPage',payload)

			document.documentElement.classList[!payload ? 'add' : 'remove']('has-aside-left','has-navbar-fixed-top')
		},
		fetch({ commit },payload) {
			axios
				.get(`data-sources/${payload}.json`)
				.then((r) => {
					if (r.data && r.data.data) {
						commit('basic',{
							key: payload,
							value: r.data.data
						})
					}
				})
				.catch(error => {
					alert(error.message)
				})
		},
		fetchBouquets({ commit },payload) {
			axios
				.get('https://localhost:44344/api/Bouquets')
				.then((r) => {
					if (r.data) {
						commit('basic',{
							key: payload,
							value: r.data
						})
					}
				})
				.catch(error => {
					alert(error.message)
				})
		},
		fetchBouquetMessages({ commit },payload) {
			axios
				.get('https://localhost:44344/api/BouquetsMessages')
				.then((r) => {
					if (r.data) {
						commit('basic',{
							key: payload,
							value: r.data
						})
					}
				})
				.catch(error => {
					alert(error.message)
				})
		},
		fetchCustomers({ commit },payload) {
			axios
				.get('https://localhost:44344/api/Customers')
				.then((r) => {
					if (r.data) {
						commit('basic',{
							key: payload,
							value: r.data
						})
					}
				})
				.catch(error => {
					alert(error.message)
				})
		},
		fetchRecipients({ commit },payload) {
			axios
				.get('https://localhost:44344/api/Recipients')
				.then((r) => {
					if (r.data) {
						commit('basic',{
							key: payload,
							value: r.data
						})
					}
				})
				.catch(error => {
					alert(error.message)
				})
		},

		deleteBouquets({ commit },payload,id) {
			axios
				.delete(`https://localhost:44344/api/Bouquets/${id}`)
				.then((r) => {
					if (r.data) {
						commit('basic',{
							key: payload,
							value: r.data
						})
					}
				})
				.catch(error => {
					alert(error.message)
				})
		},
	}
})

export default store

export function useStore() {
	return store
}
