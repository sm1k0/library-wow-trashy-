using MvvmLibrary;
using SerializationLibrary;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

public class MainViewModel : BindableBase
{
    private ObservableCollection<Person> _people;
    public ObservableCollection<Person> People
    {
        get => _people;
        set => SetProperty(ref _people, value);
    }

    private Person _selectedPerson;
    public Person SelectedPerson
    {
        get => _selectedPerson;
        set => SetProperty(ref _selectedPerson, value);
    }

    public ICommand LoadCommand { get; }
    public ICommand SaveCommand { get; }

    public MainViewModel()
    {
        People = new ObservableCollection<Person>();
        LoadCommand = new BindableCommand(_ => Load(), _ => true);
        SaveCommand = new BindableCommand(_ => Save(), _ => SelectedPerson != null);
    }

    private void Load()
    {
        People = new ObservableCollection<Person>(Serializer.Deserialize<List<Person>>("people.json"));
    }

    private void Save()
    {
        Serializer.Serialize(People, "people.json");
    }
}
