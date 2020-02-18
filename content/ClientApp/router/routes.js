import HomePage from 'components/home-page'
import Partner from 'components/partner'

export const routes = [
  { name: 'home', path: '/portal/dashboard', component: HomePage, display: 'Home', icon: 'home' },
  { name: 'Partner', path: '/portal/Partner', component: Partner, display: 'Partner', icon: 'graduation-cap' }, 
]
