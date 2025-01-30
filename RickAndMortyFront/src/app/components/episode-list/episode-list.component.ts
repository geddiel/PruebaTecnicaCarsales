import { Component, OnInit, computed } from '@angular/core';
import { EpisodeService } from '../../services/episode.service';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-episode-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './episode-list.component.html',
  styleUrls: ['./episode-list.component.css']
})
export class EpisodeListComponent implements OnInit {
  episodesPerPage = 9;

  constructor(public episodeService: EpisodeService, private router: Router) {}

  ngOnInit(): void {
    this.episodeService.getEpisodes();
  }

  goToEpisodeDetail(id: number): void {
    this.router.navigate(['/episode', id]);
  }

  get paginatedEpisodes() {
    const start = (this.episodeService.currentPage() - 1) * this.episodesPerPage;
    const end = start + this.episodesPerPage;
    return this.episodeService.episodes().slice(start, end);
  }
}
