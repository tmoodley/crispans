import CounterExample from 'components/counter-example'
import FetchData from 'components/fetch-data'
import HomePage from 'components/home-page'
import About from 'components/about'
import Customers from 'components/customers'

export const routes = [
  { name: 'home', path: '/admin', component: HomePage, display: 'Home', icon: 'home' },
  { name: 'customers', path: '/admin/customers', component: Customers, display: 'Customers', icon: 'graduation-cap' },
  { name: 'about', path: '/admin/about', component: About, display: 'About Template', icon: 'info' },
  { name: 'counter', path: '/admin/counter', component: CounterExample, display: 'Counter', icon: 'graduation-cap' },
  { name: 'fetch-data', path: '/admin/fetch-data', component: FetchData, display: 'Data', icon: 'list' }
]
