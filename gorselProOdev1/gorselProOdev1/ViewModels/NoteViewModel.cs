using gorselProOdev1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace gorselProOdev1.ViewModels
{
    public partial class NoteViewModel : INotifyPropertyChanged
    {
        //alanlar
        private string _noteBaslik;
        private string _noteTanim;
        private Notlar _selectedNot;
        
        //Get And Set 
        public String NoteBaslik
        {
            get => _noteBaslik;
            set
            {
                if(_noteBaslik != value)
                {
                    _noteBaslik = value;
                    OnPropertyChanged(); // Değeşiklikler için
                }
            }
        }
        public String NoteTanim
        {
            get => _noteTanim;
            set
            {
                if (_noteTanim != value)
                {
                    _noteTanim = value;
                    OnPropertyChanged(); // Değeşiklikler için
                }
            }
        }
        public Notlar SelectedNot
        {
            get => _selectedNot;
            set
            {
                if (_selectedNot != value)
                {
                    _selectedNot = value;
                    // notify set from list to ui
                    NoteBaslik = _selectedNot.baslik;
                    NoteTanim = _selectedNot.tanim;

                    OnPropertyChanged(); // Değeşiklikler için
                }
            }
        }


        //property
        public ObservableCollection <Notlar> NotlarCollection { get; set; }

        public ICommand AddNoteCommand { get; }
        public ICommand EditNoteCommand { get; }
        public ICommand RemoveNoteCommand { get; }





        //initalaiz
        public NoteViewModel()
        {
            NotlarCollection = new ObservableCollection<Notlar>();
            AddNoteCommand = new Command(AddNote);
            RemoveNoteCommand = new Command(RemoveNote);
            EditNoteCommand = new Command(EditeNote);


        }
        private void EditeNote(object obj)
        {
            // Edite Note 
            if (SelectedNot != null)
            {
               foreach(Notlar note in NotlarCollection.ToList())//System.InvalidOperationException: 'Collection was modified; enumeration operation may not execute.'
                {
                    // set new note
                    if(note ==SelectedNot)
                    {
                        var yeniNote = new Notlar
                        {
                            Id = note.Id,
                            baslik = NoteBaslik,
                            tanim = NoteTanim
                              
                        };
                        // Note silme islemi once 
                        NotlarCollection.Remove(note);
                        // Yeni not ekle (edited note)
                        NotlarCollection.Add(yeniNote);

                    }
                }

            }

        }
        private void RemoveNote(object obj)
        {
            // Remove Note 
            if(SelectedNot != null)
            {
                // id olusturma 
                NotlarCollection.Remove(SelectedNot);
                //Rest values
                NoteBaslik = String.Empty;
                NoteTanim = String.Empty;
            
        }
           
        }

        private void AddNote(object obj)
        {                int newId = NotlarCollection.Count > 0 ? NotlarCollection.Max(p => p.Id) + 1 : 1;

            // Yeni Note gonder (Set)
            var note = new Notlar
            {    
                Id = newId,
                tanim = NoteTanim,
                baslik = NoteBaslik,
            }; 
            NotlarCollection.Add(note); // Note ekle
                                        //Rest valu
            NoteBaslik = String.Empty;
            NoteTanim = String.Empty;
        }

        // PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;//viewda veri degişikligi olusuyor. viewda veri değişti mi değişmedi mi diye
        protected virtual void OnPropertyChanged([CallerMemberName] string propAdi =null)
        {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(propAdi));    //? bos degil ise demek
        }
    }
}
