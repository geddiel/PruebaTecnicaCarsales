import { Injectable, signal, computed } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Episode } from '../models/episode';
import { Character } from '../models/character';

@Injectable({
  providedIn: 'root'
})
export class EpisodeService {
  episodes = signal<Episode[]>([]);
  currentPage = signal<number>(1);
  totalPages = signal<number>(1);
  episodeDetail = signal<Episode | null>(null);
  characters = signal<Character[]>([]);
  itemsPerPage = 9;

  constructor(private http: HttpClient) {
    this.getEpisodes();
  }

  getEpisodes() {
    this.http.get<{ results: Episode[], total: number }>(`${environment.apiUrl}/episodes`)
      .subscribe(response => {
        if (response && response.results) {
          this.episodes.set(response.results);
          this.totalPages.set(Math.ceil(response.results.length / this.itemsPerPage));
        }
      });
  }

  getEpisodesForCurrentPage() {
    const start = (this.currentPage() - 1) * this.itemsPerPage;
    const end = start + this.itemsPerPage;
    return this.episodes().slice(start, end);
  }

  nextPage(): void {
    if (this.currentPage() < this.totalPages()) {
      this.currentPage.set(this.currentPage() + 1);
    }
  }

  prevPage(): void {
    if (this.currentPage() > 1) {
      this.currentPage.set(this.currentPage() - 1);
    }
  }

  getEpisodeDetail(id: number) {
    this.http.get<{ episode: Episode; characters: Character[] }>(
      `${environment.apiUrl}/episodes/${id}`
    ).subscribe(response => {
      this.episodeDetail.set(response.episode);
      this.characters.set(response.characters);
    });
  }
}
