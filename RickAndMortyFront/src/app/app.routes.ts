import { Routes } from '@angular/router';
import { provideRouter } from '@angular/router';
import { EpisodeListComponent } from './components/episode-list/episode-list.component';
import { EpisodeDetailComponent } from './components/episode-detail/episode-detail.component';

export const routes: Routes = [
  { path: '', component: EpisodeListComponent },
  { path: 'episode/:id', component: EpisodeDetailComponent }
];

export const appRouter = provideRouter(routes);
