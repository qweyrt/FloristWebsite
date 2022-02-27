export default [
	'General',
	[
		{
			to: '/home',
			icon: 'desktop-mac',
			label: 'Dashboard'
		}
	],
	'Examples',
	[
		{
			label: 'Tables',
			subLabel: 'Submenus Example',
			icon: 'view-list',
			menu: [
				{
					href: '/#/customers',
					label: 'Customers'
				},
				{
					href: '/#/recipients',
					label: 'Recipients'
				},
				{
					href: '/#/bouquets',
					label: 'Bouquets'
				},
				{
					href: '/#/bouquet-messages',
					label: 'Bouquet Messages'
				},
				{
					href: '/#/carts',
					label: 'Carts'
				}

			]
		},
/*  {
      to: '/tables',
      label: 'Tables',
      icon: 'table',
      updateMark: true
    },
  {
			to: '/forms',
			label: 'Forms',
			icon: 'square-edit-outline'
		},
		{
			to: '/profile',
			label: 'Profile',
			icon: 'account-circle'
		},
		{
			to: '/login',
			label: 'Login',
			icon: 'lock'
		}
*/
	],
	// 'About',
	// [
	// 	{
	// 		href: 'https://justboil.me/bulma-admin-template/one/',
	// 		label: 'Premium',
	// 		icon: 'monitor',
	// 		target: '_blank'
	// 	},
	// 	{
	// 		href: 'https://github.com/vikdiesel/admin-one-vue-bulma-dashboard',
	// 		label: 'GitHub',
	// 		icon: 'github-circle',
	// 		target: '_blank'
	// 	}
	// ]
]
