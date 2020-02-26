import Partner from 'components/partner'
import Job from 'components/job'

export const routes = [
  { name: 'home', path: '/portal/dashboard', component: Partner, display: 'Home', icon: 'home' },
  { name: 'job', path: '/portal/job/create', component: Job, display: 'Create Job', icon: 'home' },
]
