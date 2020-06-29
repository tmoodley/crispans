const RegisterOrder = () => import(/* webpackChunkName: "home" */ 'components/partner.vue')
  
export const routes = [
  { name: 'Register', path: '/Register/', component: RegisterOrder, display: 'Register', icon: 'home' }
]
