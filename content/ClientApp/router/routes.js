import Partner from 'components/partner'
import Job from 'components/job'
import Jobs from 'components/jobs'

export const routes = [
  { name: 'home', path: '/portal/dashboard', component: Partner, display: 'Home', icon: 'home' },
  { name: 'jobs', path: '/portal/job/', component: Jobs, display: 'View Jobs', icon: 'tasks' },
  { name: 'job', path: '/portal/job/create', component: Job, display: 'Create Job', icon: 'eye' },
]
